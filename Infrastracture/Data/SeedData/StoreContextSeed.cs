using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Data.SeedData
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDBContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastracture/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrands>>(brandsData);
                    if (brands.Any())
                    {
                        context.ProductBrands.AddRange(brands);
                        await context.SaveChangesAsync();
                    }
                }


                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastracture/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductTypes>>(typesData);
                    if (types.Any())
                    {
                        context.ProductTypes.AddRange(types);
                        await context.SaveChangesAsync();
                    }
                }

                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../Infrastracture/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Products>>(productData);
                    // foreach (var item in products)
                    // {
                    //     context.Products.Add(item);

                    // }
                    // await context.SaveChangesAsync();

                    if (products.Any())
                    {
                        context.Products.AddRange(products);
                        await context.SaveChangesAsync();
                    }
                }


            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}