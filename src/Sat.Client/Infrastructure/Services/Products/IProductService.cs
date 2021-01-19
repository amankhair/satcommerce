using Sat.Client.Features;
using Sat.Core.DTOs;
using Sat.Core.Entities;
using Sat.Core.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Client.Infrastructure.Services.Products
{
    public interface IProductService
    {
        Task<PagingResponse<ProductToReturnDto>> GetProducts(ProductParameters productParameters);
        Task<ProductToReturnDto> GetProductById(long id);
        Task<IReadOnlyList<ProductBrand>> GetProductBrands();
        Task<IReadOnlyList<ProductType>> GetProductTypes();
    }
}
