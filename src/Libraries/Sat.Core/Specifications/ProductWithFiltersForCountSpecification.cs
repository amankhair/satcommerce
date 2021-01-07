using Sat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
            : base(p =>
                (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) &&
                (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId))
        {

        }
    }
}
