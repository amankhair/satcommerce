using Microsoft.AspNetCore.Components;
using Sat.Client.Infrastructure.Interceptors;
using Sat.Client.Infrastructure.Services.Products;
using Sat.Core.DTOs;
using System;
using System.Threading.Tasks;

namespace Sat.Client.Pages.Shop
{
    public partial class ProductDetails : IDisposable
    {
        [Inject] public IProductService ProductService { get; set; }
        [Inject] public HttpInterceptorService Interceptor { get; set; }

        [Parameter] public long  ProductId { get; set; }
        private ProductToReturnDto ProductDto { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            ProductDto = await GetProductDetails();
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
