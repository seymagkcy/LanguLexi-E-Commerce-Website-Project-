using System.ComponentModel.DataAnnotations;

namespace LanguLexi.WebUI.Models
{
    public class UserEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Adı")]
        public string FirstName { get; set; }

        [Display(Name = "Soyadı")]
        public string LastName { get; set; }

        [Display(Name = "E-Mail")]
        public string EMailAddress  { get; set; }

        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public DateTime? BirthDate { get; set; }
    
        [Display(Name = "Profil Resmi")]
        public string? ProfileImage { get; set; }

        
    }
}
