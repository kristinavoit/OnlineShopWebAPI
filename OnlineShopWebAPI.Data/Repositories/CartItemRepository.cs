using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineShopWebAPI.Core.Models;
using OnlineShopWebAPI.Core.Repositories;

namespace OnlineShopWebAPI.Data.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public IEnumerable<CartItem> GetAllWithUsers()
        {
            return OnlineShopDbContext.CartItems
                .Include(c => c.Users)
                .ToList();
        }
        public CartItem GetWithUsersById(int id)
        {
            return OnlineShopDbContext.CartItems
                .Include(c => c.Users)
                .SingleOrDefault(c => c.Id == id);
        }
    }
}
