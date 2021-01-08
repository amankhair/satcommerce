using Sat.Core.Entities;
using Sat.Core.RequestFeatures;

namespace Sat.Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductParameters productParams)
            : base(p =>
                (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) &&
                (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId))
        {

        }
    }
}
