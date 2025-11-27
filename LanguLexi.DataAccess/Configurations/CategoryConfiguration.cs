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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Property konfigürasyonları
            
            builder.Property(c => c.Name).IsRequired().HasMaxLength(75);
            builder.Property(c => c.Image).HasMaxLength(50);

            
            // Course entity'si ile One-To-Many ilişki konfigürasyonu
            
            builder.HasMany(c => c.Courses)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);  

           
            // Seed Data Konfigürasyonu

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "İngilizce Kursu",
                    IsActive = true,
                    SequenceNo = 1,
                    ParentId = 0,
                },
                new Category
                {
                    Id = 2,
                    Name = "Almanca Kursu",
                    IsActive = true,
                    SequenceNo = 2,
                    ParentId = 0
                }
            );

        }
    }
}
