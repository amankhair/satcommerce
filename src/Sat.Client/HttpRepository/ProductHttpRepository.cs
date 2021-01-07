using Sat.Core.DTOs;
using Sat.Core.Entities;
using System.Collections.Generic;
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


        public async Task<IReadOnlyList<ProductToReturnDto>> GetProducts()
        {
            var response = await _client.GetAsync("products");
            var content = await response.Content.ReadAsStringAsync();

            var products = JsonSerializer.Deserialize<IReadOnlyList<ProductToReturnDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return products;
        }
    }
}
