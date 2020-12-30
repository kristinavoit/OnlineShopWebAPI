using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core.Repositories
{
    interface ICartItemService
    {
        IEnumerable<CartItem> GetAll();
        CartItem GetById(int id);
        void Add(CartItem newCartItem);
        void Update(CartItem cartItemToBeUpdated, CartItem cartItem);
        void Delete(CartItem cartItem);
    }
}
