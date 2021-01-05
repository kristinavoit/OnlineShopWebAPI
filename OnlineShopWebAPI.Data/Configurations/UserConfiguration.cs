using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Id)
                .UseIdentityColumn();
            builder
                .ToTable("User");
        }
    }
}
