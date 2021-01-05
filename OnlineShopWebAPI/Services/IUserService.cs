using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core.Repositories
{
    interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(User newUser);
        void Delete(User user);
    }
}
