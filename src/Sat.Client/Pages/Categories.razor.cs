using Microsoft.AspNetCore.Components;
using Sat.Client.HttpRepository;
using Sat.Core.DTOs;
using Sat.Core.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Client.Pages
{
    public partial class Categories
    {
        [Inject] public IProductHttpRepository productHttpRepository { get; set; }

        public IReadOnlyList<ProductToReturnDto> Products { get; set; } = new List<ProductToReturnDto>();
        public MetaData MetaData { get; set; } = new MetaData();
        private ProductParameters _productParameters = new ProductParameters();

        protected async override Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task GetProducts()
        {
            var response = await productHttpRepository.GetProducts(_productParameters);
            Products = response.Items;
            MetaData = response.MetaData;
        }

        private async Task SelectedPage(int page)
        {
            _productParameters.PageNumber = page;
            await GetProducts();
        }
    }
}
