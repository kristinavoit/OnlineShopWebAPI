using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core.Repositories
{
    interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product newProduct);
        void Delete(Product product);
    }
}
