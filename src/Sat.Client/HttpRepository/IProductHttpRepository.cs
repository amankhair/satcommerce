using Sat.Core.DTOs;
using Sat.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Client.HttpRepository
{
    public interface IProductHttpRepository
    {
        Task<IReadOnlyList<ProductToReturnDto>> GetProducts();
    }
}
