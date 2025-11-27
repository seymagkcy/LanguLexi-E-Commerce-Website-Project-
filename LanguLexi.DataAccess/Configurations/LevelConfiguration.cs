using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguLexi.Core.Entities;
using LanguLexi.Core.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguLexi.DataAccess.Configurations
{
    internal class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            // Property konfigürasyonları

            builder.Property(l => l.LevelCode).IsRequired().HasMaxLength(4);  
            
            builder.Property(l => l.Description).IsRequired();    

           
            // Course entity'si ile Many-To-Many ilişki konfigürasyonu 
            
            builder.HasMany(l => l.Courses)
                .WithMany(c => c.Levels)
                .UsingEntity<LevelCourse>(
                    j => j.HasOne(e => e.Course).WithMany().HasForeignKey(e => e.CourseId), 
                    j => j.HasOne(e => e.Level).WithMany().HasForeignKey(e => e.LevelId),
                    j =>
                    {
                        j.HasKey(e => new { e.LevelId, e.CourseId });  
                        j.HasIndex(e => new { e.CourseId, e.Sequence }).IsUnique();  
                   
                    }
                );



        }
    }
}
