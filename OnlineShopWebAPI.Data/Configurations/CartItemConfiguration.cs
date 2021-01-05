using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Data.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Id)
                .UseIdentityColumn();
            builder
                .ToTable("CartItem");
        }
    }
}
