using OnlineShopWebAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICartItemRepository CartItems { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        int Commit();
    }
}
