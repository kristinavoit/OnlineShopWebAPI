using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebAPI.API.Resources;
using OnlineShopWebAPI.API.Validators;
using OnlineShopWebAPI.Core.Models;
using OnlineShopWebAPI.Core.Repositories;

namespace OnlineShopWebAPI.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            this._mapper = mapper;
            this._productService = productService;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductResource>>> GetAll()
        {
            var products = await _productService.GetAll();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(productResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResource>> GetById(int id)
        {
            var product = await _productService.GetById(id);
            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResource>> Add(SaveProductResource model)
        {
            if (ModelState.IsValid)
            {
                Product item = _mapper.Map<SaveProductResource, Product>(model);
                await _productService.Insert(item);
            }
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResource>> Edit(int Id, SaveProductResource model)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            if (Id != model.Id)
            {
                return BadRequest("Ids did not match");
            }
            var productItem = await _productService.GetById(Id);
            if (productItem == null)
            {
                return NotFound();
            }
            _mapper.Map<SaveProductResource, Product>(model, productItem);
            await _productService.Update(productItem);
            return Ok(productItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetById(id);

            await _productService.Delete(product);

            return NoContent();
        }
    }
}