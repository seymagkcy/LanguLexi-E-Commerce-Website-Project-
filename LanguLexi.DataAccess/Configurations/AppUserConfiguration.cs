using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguLexi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguLexi.DataAccess.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Property konfigürasyonları

            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(75);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(75);
            builder.Property(a => a.EMailAddress).IsRequired().HasMaxLength(254); 
            builder.Property(a => a.Username).HasMaxLength(50);
            builder.Property(a => a.Password).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Phone).HasColumnType("varchar(15)").HasMaxLength(15);
            builder.Property(a => a.ProfileImage).HasMaxLength(50);  


            // Seed Data konfigürasyonu

            builder.HasData(
                new AppUser
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "User",
                    EMailAddress = "admin@langulexi.io",
                    Password= "*654321*",
                    Username = "Admin",
                    IsAdmin = true,
                    IsActive = true
                  
                }
            );
                                                                                                          
        }
    }
}
