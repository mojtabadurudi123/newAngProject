using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly StoreDBContext db;
        public ProductsRepository(StoreDBContext db)
        {
            this.db = db;
            
        }

        public async Task<IReadOnlyList<ProductBrands>> GetProductBrandsAsync()
        {
            return await db.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<Products>> GetProductsAsync()
        {
            return await db.Products
            .Include(p=>p.ProductTypes)
            .Include(p=>p.ProductBrands)
            .ToListAsync();
        }

        public async Task<Products> GetProductsByIdAsync(int id)
        {
            return await db.Products
              .Include(p=>p.ProductTypes)
            .Include(p=>p.ProductBrands)
            .SingleOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IReadOnlyList<ProductTypes>> GetProductTypesAsync()
        {
            return await db.ProductTypes.ToListAsync();
        }
    }
}