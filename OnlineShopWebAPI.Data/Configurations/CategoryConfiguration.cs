using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c=>c.Id);
            builder
                .Property(c => c.Id)
                .UseIdentityColumn();
            builder
                .ToTable("Category");
        }
    }
}
