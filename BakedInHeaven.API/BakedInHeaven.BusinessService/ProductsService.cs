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

        public void AddProduct(ProductDto product)
        {
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
    }
}
