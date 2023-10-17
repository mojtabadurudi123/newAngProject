using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public string? ProductTitle { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public string ProductTypes { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductBrands { get; set; }
        public int ProductBrandId { get; set; }
    }
}