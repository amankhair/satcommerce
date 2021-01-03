using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Core.Entities
{
    /// <summary>
    /// Represents a product
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the image url
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the product type
        /// </summary>
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Gets or sets the product type identifier
        /// </summary>
        public long ProductTypeId { get; set; }

        /// <summary>
        /// Gets or sets the product brand
        /// </summary>
        public ProductBrand ProductBrand { get; set; }

        /// <summary>
        /// Gets or sets the product brand identifier
        /// </summary>
        public long ProductBrandId { get; set; }
    }
}
