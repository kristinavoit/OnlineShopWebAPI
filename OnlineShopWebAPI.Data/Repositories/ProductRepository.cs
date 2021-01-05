using Microsoft.EntityFrameworkCore;
using OnlineShopWebAPI.Core.Models;
using OnlineShopWebAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopWebAPI.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(OnlineShopDbContext context)
            : base(context)
        { }
        public IEnumerable<Product> GetAllWithCategories()
        {
            return OnlineShopDbContext.Products
                .Include(p => p.Category)
                .ToList();
        }

        public Product GetWithCategoriesById(int id)
        {
            return OnlineShopDbContext.Products
                .Include(p => p.Category)
                .SingleOrDefault(p => p.Id == id);
        }
    }
}
