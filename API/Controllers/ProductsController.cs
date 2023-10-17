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
using Core.Specifications;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IGenericRepository<Products> _productsRepository;
        private readonly IGenericRepository<ProductBrands> _productBrandsRepo;
        private readonly IGenericRepository<ProductTypes> _productTypesRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Products> productRepo
        ,IGenericRepository<ProductBrands> productBrandsRepo
        ,IGenericRepository<ProductTypes> productTypesRepo,IMapper mapper) 
        {
            _productsRepository = productRepo;
            _productBrandsRepo = productBrandsRepo;
            _productTypesRepo = productTypesRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            var  spec=new ProductsWithTypesAndBrandsSpecification();


            var lstProducts = await _productsRepository.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Products>,IReadOnlyList<ProductToReturnDto>>(lstProducts));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
              var  spec=new ProductsWithTypesAndBrandsSpecification(id);


            Products product = await _productsRepository.GetEntityWithSpecification(spec);

            return Ok(_mapper.Map<Products,ProductToReturnDto>(product));
        }

        [HttpGet("brands")]
        public async Task<IReadOnlyList<ProductBrands>> GetProductBrandsAsync()
        {
            
            return await _productBrandsRepo.GetAllAsync();
        }

    }
}