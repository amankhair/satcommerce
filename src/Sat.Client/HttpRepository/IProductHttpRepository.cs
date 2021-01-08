using Sat.Client.Features;
using Sat.Core.DTOs;
using Sat.Core.RequestFeatures;
using System.Threading.Tasks;

namespace Sat.Client.HttpRepository
{
    public interface IProductHttpRepository
    {
        Task<PagingResponse<ProductToReturnDto>> GetProducts(ProductParameters productParameters);
    }
}
