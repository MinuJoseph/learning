using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakedInHeaven.BusinessService;
using BakedInHeaven.BusinessService.Dtos;
using BakedInHeaven.DataAccess.Entities;

namespace BakedInHeaven.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        [Route("products")]
        [HttpGet]
        public IEnumerable<ProductDto> GetAllProducts()
        {
            
            return _productsService.GetAllProducts();
        }

        [Route("products")]
        [HttpPost]
        public void AddProduct(Products product)
        {
            _productsService.AddProduct(product);
        }


        [Route("products/{id}")]
        [HttpDelete]

        public void DeleteProduct(int id)
        {
            _productsService.Delete(id);
        }

        [Route("products/{id}")]
        [HttpPut]
        public void UpdateProduct(Products product, int id)
        {
            _productsService.UpdateProduct(product, id);
        }
    }
}
