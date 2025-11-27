using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LanguLexi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LanguLexi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);  // Base Class olan DbContext'in varsayılan davranışlarını,ayarlarını vs. alabilmek için yapmamız gerekiyor.
                                                 // Bu metotta bunu yapmazsak, o default davranışları,ayarları vs. alamayız.
                                                 // Çünkü bu metodu override olarak tanımlıyoruz yani Base Class olan DbContext'in OnConfiguring(DbContextOptionsBuilder optionsBuilder) metodunu override ediyoruz.
                                                 // Bu metotta bunu yaparak; hem Program.cs'teki AddDbContext<AppDbContext>() metodunda yaptığımız ayarları kullanabiliyoruz çünkü bu metodu override ediyoruz yani kendi ayarlarımızı, davranışlarımızı vs. uygulayabiliyoruz.
                                                 //     Bu metodu override etmezsek kendi ayarlarımızı davranışlarımızı vs. uygulayamayız.
                                                 // Bu metotta bu base.OnConfiguring(optionsBuilder) çağrısını yapıyoruz ki; Base Class olan DbContext'in default davranışlarını,ayarlarını vs. alabilelim.
                                                 // Böylece; hem kendi ayarlarımızı,davranışlarımızı vs. uygulayabiliyoruz
                                                 //     hem de base class olan DbContext'in default davranışlarından,ayarlarından vs. mahrum kalmıyoruz, onları da alabiliyoruz ve uygulayabiliyoruz.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Çalışan DLL içindeki konfigürasyonları tarar ve uygular.
            
            base.OnModelCreating(modelBuilder);  // Base Class olan DbContext'in varsayılan davranışlarını,ayarlarını vs. alabilmek için yapmamız gerekiyor.
                                                 // Bu metotta bunu yapmazsak, o default davranışları,ayarları vs. alamayız.
                                                 // Çünkü bu metodu override olarak tanımlıyoruz yani Base Class olan DbContext'in OnModelCreating(ModelBuilder modelBuilder) metodunu override ediyoruz.
                                                 // Bu metotta bunu yaparak; kendi konfigürasyonlarımızı(LanguLexi.Data.Configurations klasöründeki class'larda tanımladığımız) kullanabiliyoruz çünkü bu metodu override ediyoruz yani kendi konfigürasyonlarımızı vs. uygulayabiliyoruz.
                                                 //     Bu metodu override etmezsek kendi ayarlarımızı davranışlarımızı vs. uygulayamayız.
                                                 // Bu metotta bu base.OnModelCreating(ModelBuilder modelBuilder) çağrısını yapıyoruz ki; Base Class olan DbContext'in default davranışlarını,ayarlarını vs. alabilelim.
                                                 // Böylece; hem kendi konfigürasyonlarımızı vs. uygulayabiliyoruz
                                                 //     hem de Base Class olan DbContext'in default davranışlarından,ayarlarından vs. mahrum kalmıyoruz, onları da alabiliyoruz ve uygulayabiliyoruz.
                                                 // Hatta burada bu base.OnModelCreating(modelBuilder) çağrısını; modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()) çağrısından sonra
                                                 //     yapmamızın da bir sebebi var:
                                                 // Eğer önce base.OnModelCreating(modelBuilder) çağrısını, daha sonra ise modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()) çağrısını yapsaydık;
                                                 // kendi konfigürasyonlarımız vs., default ayarları ezerdi, o zaman da zaten base.OnModelCreating(modelBuilder) diyerek default ayarları,davranışları almamıızn bir anlamı olmazdı çünkü onları kulanamazdık.

        }


    }
}
