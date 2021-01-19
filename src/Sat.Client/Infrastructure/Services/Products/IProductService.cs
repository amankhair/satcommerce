using Sat.Client.Features;
using Sat.Core.DTOs;
using Sat.Core.RequestFeatures;
using System.Threading.Tasks;

namespace Sat.Client.Infrastructure.Services.Products
{
    public interface IProductService
    {
        Task<PagingResponse<ProductToReturnDto>> GetProducts(ProductParameters productParameters);
        Task<ProductToReturnDto> GetProductById(long id);
    }
}
