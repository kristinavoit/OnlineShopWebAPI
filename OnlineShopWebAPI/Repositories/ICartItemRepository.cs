using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core.Repositories
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        IEnumerable<CartItem> GetAllWithUsers();
        CartItem GetWithUsersById(int id);
    }
}
