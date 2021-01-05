using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllWithProducts();
        User GetWithProductsById(int id);
    }
}
