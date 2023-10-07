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

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        StoreDBContext db = new StoreDBContext();
        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            var lstProducts = await db.Products.ToListAsync();

            return Ok(lstProducts);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            Products product = await db.Products.FindAsync(id);

            return Ok(product);
        }
    }
}