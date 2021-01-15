using OnlineShopWebAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopWebAPI.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICartItemRepository CartItems { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();
    }
}
