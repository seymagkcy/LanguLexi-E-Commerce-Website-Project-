using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguLexi.Core.Entities
{
    public class Contact : IEntityLanguLexi
    {
        public int Id { get; set; }

        [Display(Name = "Adınız"),Required(ErrorMessage = "Ad Boş Bırakılamaz!")]
        public string FirstName { get; set; }

        [Display(Name = "Soyadınız"), Required(ErrorMessage = "Soyad Boş Bırakılamaz!")]
        public string LastName { get; set; }

        [Display(Name = "Telefon Numaranız")]
        public string? Phone { get; set; }

        [Display(Name = "E-Mail Adresiniz")]
        public string? EMailAddress { get; set; }

        [Display(Name = "Mesajınız"), Required(ErrorMessage = "Mesaj Boş Bırakılamaz!")]
        public string ContactMessage { get; set; }

        [Display(Name = "Oluşturulduğu Tarih"), ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
