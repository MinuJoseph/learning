using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BakedInHeaven.API.Models;
using BakedInHeaven.API.Context;

namespace BakedInHeaven.API.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [Route("products")]
        [HttpGet]
        public List<Products> GetAllProducts()
        {
            using var dbContext = new BakeryDbContext();
            return dbContext.Products.ToList();

        }

        [Route("products")]
        [HttpPost]
        public bool CreateProducts(Products products)
        {
            using var dbContext = new BakeryDbContext();

            dbContext.Products.Add(products);
            dbContext.SaveChanges();

            return true;

        }
        [Route("products/{id}")]
        [HttpDelete]
        public bool DeleteProducts(Products id)
        {
            using var dbContext = new BakeryDbContext();
            dbContext.Remove(dbContext.Products.Single(a => a.Id == 1));
            dbContext.SaveChanges();

            return true;

        }


    }

}