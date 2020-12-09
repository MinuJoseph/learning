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

            public bool Delete(int id)
            {
                var products = _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
                if (products != null)
                {
                    try
                    {

                        _dbContext.Products.Remove(products);
                        _dbContext.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw;

                    }

                }
                else
                {
                    return false;
                }
            }

            public bool Update(Products productEntity, int id)
            {
                var products1 = _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();

                if (products1 != null)
                {
                    try
                    {
                        products1.Name = productEntity.Name;
                        products1.AvailableDate = productEntity.AvailableDate;
                        products1.Quantity = productEntity.Quantity;
                        products1.WeightInGrams = productEntity.WeightInGrams;
                        products1.IsSpecial = productEntity.IsSpecial;
                        products1.Kcal = productEntity.Kcal;
                        products1.IsVeg = productEntity.IsVeg;
                        products1.Price = productEntity.Price;

                        _dbContext.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }

        public List<Products> GetProducts()
        {
            return _dbContext.Products.ToList();

        }

    }
    }
