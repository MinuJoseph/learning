using BakedInHeaven.BusinessService.Dtos;
using BakedInHeaven.DataAccess.Entities;
using System.Collections.Generic;


namespace BakedInHeaven.BusinessService
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAllProducts();

        //void AddProduct(ProductDto product);

        void Delete(int id);
        void UpdateProduct(Products products, int id);
        void AddProduct(Products New_data);


    }
}