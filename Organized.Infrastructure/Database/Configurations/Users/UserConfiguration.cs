using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organized.Domain.Entities.Users;

namespace Organized.Infrastructure.Database.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);  

            builder.Property(u => u.Id)
                   .HasColumnName("id");

            builder.Property(u => u.Name)
                   .HasColumnName("name");

            builder.Property(u => u.Email)
                   .HasColumnName("email")
                   .IsRequired();

            
        }
    }
}
