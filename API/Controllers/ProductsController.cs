using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastracture.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productsRepository) 
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            var lstProducts = await productsRepository.GetProductsAsync();

            return Ok(lstProducts);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            Products product = await productsRepository.GetProductsByIdAsync(id);

            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<IReadOnlyList<ProductBrands>> GetProductBrandsAsync()
        {

            return await productsRepository.GetProductBrandsAsync();
        }

    }
}