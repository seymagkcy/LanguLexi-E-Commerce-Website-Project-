using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguLexi.Core.Entities
{
    public class AppUser : IEntityLanguLexi
    {
        public int Id { get; set; }

        [Display(Name = "Adı")]
        public string FirstName { get; set; }

        [Display(Name = "Soyadı")]
        public string LastName { get; set; }

        [Display(Name = "E-Mail")]
        public string EMailAddress { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string? Username { get; set; }

        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name= "Telefon")]
        public string? Phone {  get; set; }

        [Display(Name = "Doğum Tarihi")]       
        public DateTime? BirthDate { get; set; }  

        [Display(Name = "Profil Resmi")]
        public string? ProfileImage { get; set; }

        [Display(Name= "Admin Mi?")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }

        [Display(Name = "Oluşturulduğu Tarih"), ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)]
        public Guid? AppUserGuid { get; set; } = Guid.NewGuid();  

        public List<Order>? Orders { get; set; }  

    }
}
