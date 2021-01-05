using Microsoft.EntityFrameworkCore;
using OnlineShopWebAPI.Core.Models;
using OnlineShopWebAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopWebAPI.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public IEnumerable<Category> GetAllWithProducts()
        {
            return OnlineShopDbContext.Categories
                .Include(c => c.Product)
                .ToList();
        }
        public Category GetWithProductsById(int id)
        {
            return OnlineShopDbContext.Categories
                .Include(c => c.Product)
                .SingleOrDefault(c => c.Id == id);
        }
    }
}
