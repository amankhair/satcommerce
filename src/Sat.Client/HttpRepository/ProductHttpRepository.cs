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

namespace Sat.Client.HttpRepository
{
    public class ProductHttpRepository : IProductHttpRepository
    {
        #region Fields

        private readonly HttpClient _client;

        #endregion

        #region Ctor

        public ProductHttpRepository(HttpClient client)
        {
            _client = client;
        }

        #endregion


        public async Task<PagingResponse<ProductToReturnDto>> GetProducts(ProductParameters productParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = productParameters.PageNumber.ToString()
            };

            var response = await _client.GetAsync(QueryHelpers.AddQueryString("products", queryStringParam));
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
    }
}
