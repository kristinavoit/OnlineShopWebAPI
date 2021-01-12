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
        public ActionResult<IEnumerable<ProductResource>> GetAll()
        {
            var products =  _productService.GetAll();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(productResources);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductResource> GetById(int id)
        {
            var product = _productService.GetById(id);
            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpPost("")]
        public ActionResult<ProductResource> Add([FromBody] SaveProductResource saveProductResource)
        {
            var validator = new SaveProductResourceValidator();
            var validationResult = validator.Validate(saveProductResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var artistToCreate = _mapper.Map<SaveProductResource, Product>(saveProductResource);

            var newProduct = _productService.Add(artistToCreate);

            var product = _productService.GetById(newProduct.Id);

            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductResource> UpdateArtist(int id, [FromBody] SaveProductResource saveProductResource)
        {
            var validator = new SaveProductResourceValidator();
            var validationResult = validator.Validate(saveProductResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var productToBeUpdated = _productService.GetById(id);

            if (productToBeUpdated == null)
                return NotFound();

            var product = _mapper.Map<SaveProductResource, Product>(saveProductResource);

            _productService.Update(productToBeUpdated, product);

            var updatedProduct = _productService.GetById(id);

            var updatedProductResource = _mapper.Map<Product, ProductResource>(updatedProduct);

            return Ok(updatedProductResource);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);

            _productService.Delete(product);

            return NoContent();
        }
    }
}