using Microsoft.EntityFrameworkCore;
using OnlineShopWebAPI.Data.Configurations;
using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Data
{
    public class OnlineShopDbContext : DbContext
    {
        public static DbSet<CartItem> CartItems { get; set; }
        public static DbSet<Category> Categories { get; set; }
        public static DbSet<Product> Products { get; set; }
        public static DbSet<User> Users { get; set; }

        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
            : base (options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new CartItemConfiguration());
            builder
                .ApplyConfiguration(new CategoryConfiguration());
            builder
                .ApplyConfiguration(new ProductConfiguration());
            builder
                .ApplyConfiguration(new UserConfiguration());
        }

    }
}
