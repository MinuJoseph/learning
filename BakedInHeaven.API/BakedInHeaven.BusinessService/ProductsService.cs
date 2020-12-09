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

        public void Delete(int id)
        {
            var products = _productsRepository.Delete(id);
        }
        public void UpdateProduct(Products products, int id)
        {
            bool c = _productsRepository.Update(products,id);

        }

        public void AddProduct(Products New_data) 
        {
            List<Products> data = new List<Products>();
            data = _productsRepository.GetProducts(); // fetch the entire database
            int Total = data.Where(x => x.AvailableDate == New_data.AvailableDate).Count();
            int flag = 0;
            int count = 0;
           
            if (Total < 15)
            {
                foreach (var Element in data)
                {
                    if (Element.Name == New_data.Name && Element.AvailableDate == New_data.AvailableDate)
                    {
                        break;
                        // " with same name already exist for the date";
                    }

                    else { flag = 1; }

                }
            }
            if (flag == 1)
            {

                if (New_data.IsSpecial == true)
                {
                    foreach (var Element in data)
                    {
                        if (Element.AvailableDate == New_data.AvailableDate)
                        {
                            if (Element.IsSpecial == true)
                            {
                                count++;
                            }
                        }

                    }
                    if (count < 4) { _productsRepository.Add(New_data); }


                }
                else
                {
                    _productsRepository.Add(New_data);
                }
            }
        }

    }
}