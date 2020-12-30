﻿using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core.Repositories
{
    interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllWithProducts();
        Category GetWithProductsById(int id);
    }
}
