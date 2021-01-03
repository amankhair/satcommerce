using Sat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Core.Interfaces
{
    public interface IRepositoryManager
    {
        IGenericRepository<Product> Products { get; }
        IGenericRepository<ProductBrand> ProductBrands { get; }
        IGenericRepository<ProductType> ProductTypes { get; }
    }
}
