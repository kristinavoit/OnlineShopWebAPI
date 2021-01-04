using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public IEnumerable<Category> GetAllWithUsers()
        {
            return OnlineShopDbContext.Categories
                .Include(c => c.Users)
                .ToList();
        }
        public CartItem GetWithUsersById(int id)
        {
            return OnlineShopDbContext.CartItems
                .Include(c => c.Users)
                .SingleOrDefault(c => c.Id == Id);
        }
    }
}
