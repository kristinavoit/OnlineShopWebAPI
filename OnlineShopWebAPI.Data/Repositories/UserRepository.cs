using Microsoft.EntityFrameworkCore;
using OnlineShopWebAPI.Core.Models;
using OnlineShopWebAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopWebAPI.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(OnlineShopDbContext context)
            : base(context)
        { }
        public IEnumerable<User> GetAllWithProducts()
        {
            return OnlineShopDbContext.Users
                .Include(u => u.Product)
                .ToList();
        }

        public User GetWithProductsById(int id)
        {
            return OnlineShopDbContext.Users
                .Include(u => u.Product)
                .SingleOrDefault(u => u.Id == id);
        }
    }
}
