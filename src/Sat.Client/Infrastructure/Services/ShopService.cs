using Microsoft.AspNetCore.WebUtilities;
using Sat.Client.Features;
using Sat.Core.DTOs;
using Sat.Core.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sat.Client.Infrastructure.Services
{
    public class ShopService
    {
        #region Fields

        private readonly HttpClient _client;

        #endregion Fields

        #region Consts

        private const string ProductPath = "products";

        #endregion Consts

        #region Ctor

        public ShopService(HttpClient client)
        {
            _client = client;
        }

        #endregion Ctor

        public async Task<PagingResponse<ProductToReturnDto>> GetProducts(ProductParameters productParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["search"] = productParameters.Search == null ? "" : productParameters.Search,
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
