using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductsRepository
    {
        public Task<Products> GetProductsByIdAsync(int id);
        public Task<IReadOnlyList<Products>> GetProductsAsync();
        public Task<IReadOnlyList<ProductBrands>> GetProductBrandsAsync();
        public Task<IReadOnlyList<ProductTypes>> GetProductTypesAsync();



    }
}