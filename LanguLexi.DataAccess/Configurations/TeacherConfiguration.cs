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
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Property konfigürasyonları

            builder.Property(t => t.FirstName).IsRequired().HasMaxLength(75);
            builder.Property(t => t.LastName).IsRequired().HasMaxLength(75);
            builder.Property(t => t.Title).HasMaxLength(75);
            builder.Property(t => t.ProfileImage).HasMaxLength(50);


            // Course entity'si ile Many-To-Many ilişki konfigürasyonu 

            builder.HasMany(t => t.Courses)
                .WithMany(c => c.Teachers)
                .UsingEntity<TeacherCourse>(
                    j => j.HasOne(e => e.Course).WithMany().HasForeignKey(e => e.CourseId),
                    j => j.HasOne(e => e.Teacher).WithMany().HasForeignKey(e => e.TeacherId),
                    j =>
                    {
                        j.HasKey(e => new { e.TeacherId, e.CourseId });  
                        j.HasIndex(e => new { e.CourseId, e.DisplaySequence }).IsUnique();  
                    }
                );
        }
    }
}
