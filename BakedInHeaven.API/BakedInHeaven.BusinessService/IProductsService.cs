using BakedInHeaven.BusinessService.Dtos;
using System.Collections.Generic;


namespace BakedInHeaven.BusinessService
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAllProducts();

        void AddProduct(ProductDto product);

    }
}