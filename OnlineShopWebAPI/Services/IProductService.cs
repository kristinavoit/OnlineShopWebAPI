using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopWebAPI.Core.Repositories
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Insert(Product newProduct);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
