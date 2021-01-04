using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core.Repositories
{
    interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Add(Category newCategory);
        void Delete(Category category);
    }
}
