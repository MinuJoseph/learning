using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BakedInHeaven.BusinessService.Dtos;
using BakedInHeaven.DataAccess.Entities;
using BakedInHeaven.DataAccess.Repositories;

namespace BakedInHeaven.BusinessService
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public string AddProduct(ProductDto product)
        {
            string message = "";
            var currentDate = DateTime.Now.Date;
            var currentDateProducts = _productsRepository.GetProductsByDate(currentDate);
            var existingNameProducts = currentDateProducts.Where(x => x.Name == product.Name);

            if (existingNameProducts != null)
            {
                message = "The name must be unique for the day";
            }

            if(currentDateProducts.Count >= 15)
            {
                message = "You can't add more than 15 items in a day";
            }

            if(product.IsSpecial && currentDateProducts.Count(x=>x.IsSpecial) >= 4)
            {
                message = "You can't add more than 4 special items in a day";
            }

            var productEntity = new Products
            {
                AvailableDate = product.AvailableDate,
                IsSpecial = product.IsSpecial,
                IsVeg = product.IsVeg,
                Kcal = product.Kcal,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                WeightInGrams = product.WeightInGrams
            };

            _productsRepository.Add(productEntity);
            return message;
        }

        public void Delete(int id)
        {
            var products = _productsRepository.Delete(id);
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _productsRepository.GetAllProducts();

            return products.Select(p => new ProductDto
            {
                AvailableDate = p.AvailableDate,
                Id = p.Id,
                IsSpecial = p.IsSpecial,
                IsVeg = p.IsVeg,
                Kcal = p.Kcal,
                Price = p.Price,
                Quantity = p.Quantity,
                Name = p.Name,
                WeightInGrams = p.WeightInGrams
            });
        }

        public void UpdateProduct(Products products, int id)
        {
            bool c = _productsRepository.Update(products, id);
        }


        


    }





}