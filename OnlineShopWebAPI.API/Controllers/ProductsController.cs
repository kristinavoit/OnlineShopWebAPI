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
        private IProductService productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            _mapper = mapper;
        }
        [HttpGet("")]
        public ActionResult<IEnumerable<ProductResource>> GetAll()
        {
            var products = productService.GetAll();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(productResources);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductResource> GetById(int id)
        {
            var product = productService.GetById(id);
            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpPost]
        public ActionResult<ProductResource> Add(SaveProductResource model)
        {
            if (ModelState.IsValid)
            {
                Product item = _mapper.Map<SaveProductResource, Product>(model);
                productService.Insert(item);
            }
            return Ok(model);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductResource> Edit(int Id, SaveProductResource model)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            if (Id != model.Id)
            {
                return BadRequest("Ids did not match");
            }
            var productItem = productService.GetById(Id);
            if (productItem == null)
            {
                return NotFound();
            }
            _mapper.Map<SaveProductResource, Product>(model, productItem);
            productService.Update(productItem);
            return Ok(productItem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = productService.GetById(id);

            productService.Delete(product);

            return NoContent();
        }
    }
}