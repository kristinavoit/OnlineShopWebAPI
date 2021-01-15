using OnlineShopWebAPI.Core;
using OnlineShopWebAPI.Core.Repositories;
using OnlineShopWebAPI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopWebAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineShopDbContext _context;
        private CartItemRepository _cartItemRepository;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private UserRepository _userRepository;
        public UnitOfWork(OnlineShopDbContext context)
        {
            this._context = context;
        }
        public ICartItemRepository CartItems => _cartItemRepository = _cartItemRepository ?? new CartItemRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
