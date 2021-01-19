using Microsoft.AspNetCore.WebUtilities;
using Sat.Client.Features;
using Sat.Core.DTOs;
using Sat.Core.Entities;
using Sat.Core.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sat.Client.Infrastructure.Services.Products
{
    public class ProductService : IProductService
    {
        #region Fields

        private readonly HttpClient _httpClient;

        #endregion Fields

        #region Consts

        private const string ProductsPath = "products";
        private const string Brands = "brands";
        private const string Types = "types";

        #endregion Consts

        #region Ctor

        public ProductService(HttpClient httpClient) => _httpClient = httpClient;

        #endregion Ctor

        // get all products
        public async Task<PagingResponse<ProductToReturnDto>> GetProducts(ProductParameters productParameters)
        {
            var queryStringParam = new Dictionary<string, string>();

            if (productParameters.BrandId != 0) 
                queryStringParam.Add("brandId", productParameters.BrandId.ToString());

            if (productParameters.TypeId != 0)
                queryStringParam.Add("typeId", productParameters.TypeId.ToString());

            if (!string.IsNullOrEmpty(productParameters.Search))
                queryStringParam.Add("search", productParameters.Search);

            if (!string.IsNullOrEmpty(productParameters.Sort))
                queryStringParam.Add("sort", productParameters.Sort);

            queryStringParam.Add("pageNumber", productParameters.PageNumber.ToString());


            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString(ProductsPath, queryStringParam));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var pagingResponse = new PagingResponse<ProductToReturnDto>
            {
                Items = JsonSerializer.Deserialize<IReadOnlyList<ProductToReturnDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            };

            return pagingResponse;
        }

        // get product by id
        public async Task<ProductToReturnDto> GetProductById(long id)
        {
            var response = await _httpClient.GetAsync($"{ProductsPath}/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var productResponse = JsonSerializer.Deserialize<ProductToReturnDto>(
                content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return productResponse;
        }

        // get product types
        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            var response = await _httpClient.GetAsync($"{ProductsPath}/{Types}");
            var content = await response.Content.ReadAsStringAsync();

            var productTypes = JsonSerializer.Deserialize<IReadOnlyList<ProductType>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return productTypes;
        }

        // get product brands
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            var response = await _httpClient.GetAsync($"{ProductsPath}/{Brands}");
            var content = await response.Content.ReadAsStringAsync();

            var productBrands = JsonSerializer.Deserialize<IReadOnlyList<ProductBrand>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return productBrands;
        }
    }
}
