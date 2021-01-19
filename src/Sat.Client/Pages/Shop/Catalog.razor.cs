using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Sat.Client.Extensions;
using Sat.Client.Infrastructure.Services.Products;
using Sat.Core.DTOs;
using Sat.Core.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Client.Pages.Shop
{
    public partial class Catalog : IDisposable
    {
        #region Injects

        [Inject] public IProductService productService { get; set; }
        [Inject] public NavigationManager navManager { get; set; }

        #endregion Injects

        #region Props

        public IReadOnlyList<ProductToReturnDto> Products { get; set; } = new List<ProductToReturnDto>();
        public MetaData MetaData { get; set; } = new MetaData();
        private ProductParameters _productParameters { get; set; } = new ProductParameters();

        #endregion Props


        protected async override Task OnInitializedAsync()
        {
            await GetQueryStringValues();
            navManager.LocationChanged += HandleLocationChanged;
        }

        // show all products in shop page
        private async Task GetProducts()
        {
            var response = await productService.GetProducts(_productParameters);
            Products = response.Items;
            MetaData = response.MetaData;
        }

        private async Task GetBrands()
        {

        }

        // pagination
        private async Task SelectedPage(int page)
        {
            _productParameters.PageNumber = page;
            await GetProducts();
        }

        #region QueryStrings Methods

        private async Task GetQueryStringValues()
        {
            _productParameters.Search = navManager.ExtractQueryStringByKey<string>("text");
            await GetProducts();
        }

        private async void HandleLocationChanged(object sender, LocationChangedEventArgs e)
        {
            await GetQueryStringValues();
            StateHasChanged();
        }

        public void Dispose()
        {
            navManager.LocationChanged -= HandleLocationChanged;
        }

        #endregion QueryStrings Methods
    }
}
