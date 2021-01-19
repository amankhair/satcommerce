using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Sat.Client.Extensions;
using Sat.Client.Infrastructure.Services.Products;
using Sat.Core.DTOs;
using Sat.Core.Entities;
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
        public IReadOnlyList<ProductBrand> ProductBrands { get; set; } = new List<ProductBrand>();
        public IReadOnlyList<ProductType> ProductTypes { get; set; } = new List<ProductType>();
        public MetaData MetaData { get; set; } = new MetaData();
        private ProductParameters _productParameters { get; set; } = new ProductParameters();

        #endregion Props
        

        public string SelectedProductType { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetProductBrands();
            await GetProductTypes();
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

        // get product brands
        private async Task GetProductBrands()
        {
            ProductBrands = await productService.GetProductBrands();
        }

        // get product types
        private async Task GetProductTypes()
        {
            ProductTypes = await productService.GetProductTypes();
        }

        public string SelectedBrand { get; set; }

        public string GetBClass(string item) =>
            SelectedBrand == item ? "active" : "";

        public string GetTClass(string item) =>
            SelectedProductType == item ? "active" : "";

        // pagination
        private async Task SelectedPage(int page)
        {
            _productParameters.PageNumber = page;
            await GetProducts();
        }

        private async Task OnTypeSelected(long typeId, string typeName)
        {
            SelectedProductType = typeName;
            _productParameters.TypeId = typeId;
            _productParameters.PageNumber = 1;
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
