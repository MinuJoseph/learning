using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakedInHeaven.BusinessService;
using BakedInHeaven.BusinessService.Dtos;

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
        [HttpGet]
        public IEnumerable<ProductDto> GetAllProducts()
        {
            
            return _productsService.GetAllProducts();
        }

        [HttpPost]
        public void AddProduct(ProductDto product)
        {
            _productsService.AddProduct(product);
        }
    }
}
