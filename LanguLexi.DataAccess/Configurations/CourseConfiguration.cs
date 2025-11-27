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
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Property konfigürasyonları

            builder.Property(c => c.Title).IsRequired().HasMaxLength(175);
            builder.Property(c => c.CourseCode).HasMaxLength(50);
            builder.Property(c => c.Image).HasMaxLength(50);

        }
    }
}
