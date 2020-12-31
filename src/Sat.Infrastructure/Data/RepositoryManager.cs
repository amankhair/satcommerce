using Sat.Core.Entities;
using Sat.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Infrastructure.Data
{
    public class RepositoryManager : IRepositoryManager
    {
        private StoreContext _context;
        private IGenericRepository<Product> _products;
        private IGenericRepository<ProductBrand> _productBrands;
        private IGenericRepository<ProductType> _productTypes;

        public RepositoryManager(StoreContext context)
        {
            _context = context;
        }

        public IGenericRepository<Product> Products
        {
            get
            {
                if (_products == null)
                    _products = new GenericRepository<Product>(_context);

                return _products;
            }
        }

        public IGenericRepository<ProductBrand> ProductBrands
        {
            get
            {
                if (_productBrands == null)
                    _productBrands = new GenericRepository<ProductBrand>(_context);

                return _productBrands;
            }
        }

        public IGenericRepository<ProductType> ProductTypes
        {
            get
            {
                if (_productTypes == null)
                    _productTypes = new GenericRepository<ProductType>(_context);

                return _productTypes;
            }
        }
    }
}
