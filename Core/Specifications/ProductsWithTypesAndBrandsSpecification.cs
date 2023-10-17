using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;


namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Products>
    {
        public ProductsWithTypesAndBrandsSpecification() 
        {
            AddInclude(x=> x.ProductTypes);
            AddInclude(x=>x.ProductBrands);
        }

        public ProductsWithTypesAndBrandsSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x=> x.ProductTypes);
            AddInclude(x=>x.ProductBrands);
        }
    }
}