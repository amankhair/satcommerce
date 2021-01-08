using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sat.Core.DTOs;
using Sat.Core.Entities;
using Sat.Core.Interfaces;
using Sat.Core.RequestFeatures;
using Sat.Core.Specifications;
using Sat.Server.Errors;
using Sat.Server.Paging;
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
        public async Task<ActionResult<PagedList<ProductToReturnDto>>> GetProducts(
            [FromQuery]ProductParameters productParams)
        {
            var specification = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpecification = new ProductWithFiltersForCountSpecification(productParams);
            var totalItems = await _repositoryManager.Products.CountAsync(countSpecification);
            var productsFromDb = await _repositoryManager.Products.ListAsync(specification);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(productsFromDb);
            var productsWithParams = new PagedList<ProductToReturnDto>(productParams.PageNumber, productParams.PageSize, totalItems, data);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(productsWithParams.MetaData));

            return Ok(productsWithParams.Items);
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