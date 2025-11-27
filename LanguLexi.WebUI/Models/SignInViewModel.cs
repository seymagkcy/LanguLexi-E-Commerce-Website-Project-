using System.ComponentModel.DataAnnotations;

namespace LanguLexi.WebUI.Models
{
    public class SignInViewModel
    {
        [DataType(DataType.EmailAddress), Required(ErrorMessage = "E-Mail Boş Bırakılamaz!")]
        [Display(Name = "E-Mail")]
        public string EMailAddress { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage="Şifre Boş Bırakılamaz!")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
