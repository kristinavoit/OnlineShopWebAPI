using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core.Repositories
{
    interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(int id);
        void Delete(int id);
    }
}
