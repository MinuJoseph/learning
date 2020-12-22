using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BakedInHeaven.API.Models;
using BakedInHeaven.API.Context;
using Microsoft.AspNetCore.Http;

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

        [Route("products/{id}")]
        [HttpGet]
        public ActionResult<Products> GetProduct(int id)
        {
            using var dbContext = new BakeryDbContext();
            var Products = dbContext.Products.Find(id);
            return Products;

        }

       


        [Route("products")]
        [HttpPost]
        public ActionResult CreateProducts(Products products)
        {
            using var dbContext = new BakeryDbContext();

            dbContext.Products.Add(products);
            dbContext.SaveChanges();
            var response = dbContext.Add(products);
            if (!string.IsNullOrEmpty(response))
            {
                return Ok();
            }
            return BadRequest(response);

            

        }
        

        [Route("products/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            using(BakeryDbContext dbContext = new BakeryDbContext())
            {
                
                dbContext.Products.Remove(dbContext.Products.FirstOrDefault(e => e.Id == id));
                dbContext.SaveChanges();

                return true;
            }
        }

        [Route("products/{id}")]
        [HttpPut]
        public bool Update(int id, [FromBody] Products products)
        {
            using (BakeryDbContext dbContext = new BakeryDbContext())
            {
                var a = dbContext.Products.FirstOrDefault(e => e.Id == id);

                a.Id = products.Id;
                a.Name = products.Name;
                a.Quantity = products.Quantity;
                a.Price = products.Price;
                a.WeightInGrams = products.WeightInGrams;
                a.Kcal = products.Kcal;
                a.IsVeg = products.IsVeg;
                a.IsSpecial = products.IsSpecial;
                a.AvailableDate = products.AvailableDate;


                dbContext.SaveChanges();

                return true;
            }
        }







    }

}