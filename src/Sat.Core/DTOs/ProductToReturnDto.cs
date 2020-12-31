using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Core.DTOs
{
    public class ProductToReturnDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}
