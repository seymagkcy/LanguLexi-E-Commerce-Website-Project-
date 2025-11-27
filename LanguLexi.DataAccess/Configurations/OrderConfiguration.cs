using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LanguLexi.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguLexi.DataAccess.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Property konfigürasyonları

            builder.Property(o => o.OrderNumber).IsRequired().HasMaxLength(50);
            builder.Property(o => o.FullNameOfUser).IsRequired().HasMaxLength(150);


        }
    }
}
