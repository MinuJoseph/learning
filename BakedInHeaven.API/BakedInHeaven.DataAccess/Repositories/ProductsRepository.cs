using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BakedInHeaven.DataAccess.Context;
using BakedInHeaven.DataAccess.Entities;

namespace BakedInHeaven.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Add(Products productEntity)
        {
            _dbContext.Products.Add(productEntity);
            _dbContext.SaveChanges();
        }

        public List<Products> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }
    }
}
