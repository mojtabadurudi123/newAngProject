using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Products:BaseEntity
    {
        public string? ProductTitle { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public ProductTypes ProductTypes { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrands ProductBrands { get; set; }
        public int ProductBrandId { get; set; }
    }

   
}