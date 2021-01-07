using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Core.DTOs;
using Sat.Core.Entities;
using Sat.Core.Interfaces;
using Sat.Core.Specifications;
using Sat.Server.Errors;
using Sat.Server.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Server.Controllers
{
    public class ProductsController : BaseApiController
    {
        #region Fields

        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public ProductsController(
            IRepositoryManager repositoryManager, 
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        #endregion

        #region Products List

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
            [FromQuery]ProductSpecParams productParams)
        {
            var specification = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpecification = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await _repositoryManager.Products.CountAsync(specification);
            var products = await _repositoryManager.Products.ListAsync(specification);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        #endregion

        #region Product details

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(long id)
        {
            var specification = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _repositoryManager.Products.GetEntityWithSpecification(specification);

            if (product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        #endregion

        #region Product Brands

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repositoryManager.ProductBrands.ListAllAsync());
        }

        #endregion

        #region Product Types

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductBrandsType()
        {
            return Ok(await _repositoryManager.ProductTypes.ListAllAsync());
        }

        #endregion
    }
}