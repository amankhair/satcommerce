using Microsoft.AspNetCore.Components;
using Sat.Client.Infrastructure.Services.Products;
using Sat.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Client.Pages.Shop
{
    public partial class ProductDetails
    {
        [Inject] public IProductService ProductService { get; set; }
        [Parameter] public long  ProductId { get; set; }
        private ProductToReturnDto ProductDto { get; set; }


        protected override async Task OnInitializedAsync()
        {
            ProductDto = await GetProductDetails();
        }

        private async Task<ProductToReturnDto> GetProductDetails()
        {
            var product = await ProductService.GetProductById(ProductId);

            return product;
        }

        
    }
}
