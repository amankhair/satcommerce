using Microsoft.AspNetCore.Components;
using Sat.Client.Components;
using Sat.Client.Infrastructure.Interceptors;
using Sat.Client.Infrastructure.Services.Products;
using Sat.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Client.Pages.Shop
{
    public partial class ProductDetails : IDisposable
    {
        [Inject] public IProductService ProductService { get; set; }
        [Inject] public HttpInterceptorService Interceptor { get; set; }

        [Parameter] public long  ProductId { get; set; }
        private ProductToReturnDto ProductDto { get; set; }
        public List<BreadCrumbData> breadCrumbDatas = new List<BreadCrumbData>();

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            ProductDto = await GetProductDetails();
            GetBreadCrumb();
        }

        private void GetBreadCrumb()
        {
            breadCrumbDatas = new List<BreadCrumbData>
            {
                new BreadCrumbData { Text = "Shop", Url = "shop" },
                new BreadCrumbData { Text = "Catalog", Url = "shop/c/categories" },
                new BreadCrumbData { Text = ProductDto.ProductType, Url = "" },
            };
        }

        public async Task<ProductToReturnDto> GetProductDetails()
        {
            var product = await ProductService.GetProductById(ProductId);
            return product;
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }
    }
}
