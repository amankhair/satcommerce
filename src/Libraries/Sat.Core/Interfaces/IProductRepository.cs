using Sat.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(long id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<List<ProductBrand>> GetProductBrandsAsync();
        Task<List<ProductType>> GetProductTypesAsync();
    }
}
