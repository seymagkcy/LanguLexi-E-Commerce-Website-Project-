using System.Drawing.Text;
using LanguLexi.Core.Entities;
using LanguLexi.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using LanguLexi.WebUI.Models;

using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;
using LanguLexi.WebUI.HelperClasses;
using Microsoft.Identity.Client;

namespace LanguLexi.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<Order> _orderRepository;

        public AccountController(IRepository<AppUser> userRepository, IRepository<Order> orderRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            AppUser user = await _userRepository.RetrieveAsync(a => a.AppUserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
            
            if (user == null)
            {
                return NotFound();
            }

            var userEditViewModel = new UserEditViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EMailAddress = user.EMailAddress,
                Password = user.Password,
                Phone = user.Phone
            };
            return View(userEditViewModel);
        }


        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexAsync(UserEditViewModel userEditViewModel)
        {
            if (ModelState.IsValid)
            {
                try 
                {
                    AppUser user = await _userRepository.RetrieveAsync(a => a.AppUserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
                    
                    if (user != null)
                    {
                        user.FirstName = userEditViewModel.FirstName;
                        user.LastName = userEditViewModel.LastName;
                        user.EMailAddress = userEditViewModel.EMailAddress;
                        user.Password = userEditViewModel.Password;
                        user.Phone = userEditViewModel.Phone;
                        _userRepository.Update(user);

                        var sonuc = _userRepository.SaveChanges();

                        if (sonuc > 0)
                        {
                            TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                        <strong>Bilgileriniz Güncellenmiştir!</strong>
    <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
    </div>";
                            // await MailHelper.SendMailAy-sync(contact);
                            return RedirectToAction("Index");

                        }
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata oluştu");
                }
            }
            return View(userEditViewModel);
        }



        public IActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignInAsync(SignInViewModel signInViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = await _userRepository.RetrieveAsync(a => a.EMailAddress == signInViewModel.EMailAddress & a.Password == signInViewModel.Password & a.IsActive);

                    if(account == null)
                    {
                        ModelState.AddModelError("", "Giriş Başarısız");
                    }

                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.GivenName, account.FirstName),
                            new Claim(ClaimTypes.Surname, account.LastName),
                            new Claim(ClaimTypes.Email, account.EMailAddress),
                            new Claim(ClaimTypes.Role, account.IsAdmin ? "Admin" : "Customer"),
                            new Claim("UserId", account.Id.ToString()),
                            new Claim("UserGuid", account.AppUserGuid.ToString())
                        };

                        var userIdentity = new ClaimsIdentity(claims, "Login");
                        ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
                        await HttpContext.SignInAsync(userPrincipal);
                        return Redirect(string.IsNullOrEmpty(signInViewModel.ReturnUrl) ? "/" : signInViewModel.ReturnUrl);
                    }
                }
                catch (Exception)
                {
                    // loglama
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(signInViewModel);
        }


        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUpAsync(AppUser appUser, IFormFile formImage)
        {
            appUser.IsAdmin = false;
            appUser.IsActive = true;
            if (ModelState.IsValid)
            {
                try
                {
                    appUser.ProfileImage = await FileHelper.FileLoaderAsync(formImage, "/img/AppUserProfilePhotos");
                    await _userRepository.AddAsync(appUser);
                    await _userRepository.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(appUser);
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPasswordAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("", "E-Mail Boş Bırakılamaz!");
                return View();
            }

            AppUser appUser = await _userRepository.RetrieveAsync(a => a.EMailAddress == email);
            if (appUser == null)
            {
                ModelState.AddModelError("","Girdiğiniz E-Mail adresiyle kayıtlı bir hesap bulunmamaktadır.");
                return View();
            }

            string message = $"Sayın {appUser.FirstName} {appUser.LastName}, <br> Şifrenizi sıfırlamak için lütfen <a href='https://localhost:7239/Account/ChangePassword?user={appUser.AppUserGuid.ToString()}'>Buraya Tıklayınız</a> ";
            var result = await MailHelper.SendMailAsync(email,"Şifremi Sıfırla",message);
            if (result)
            {
                TempData["Message"] = @"<div class=""alert alert-danger alert-dismissible fade show"" role=""alert"">
                        <strong>Şifre Sıfırlama Bağlantınız Mail Adresinize Gönderilmiştir!</strong>
    <button type=""button""class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close"" ></button>
    </div>";
            }
            else
            {
                TempData["Message"] = @"<div class=""alert alert-danger alert-dismissible fade show"" role=""alert"">
                        <strong>Şifre Sıfırlama Bağlantınız Mail Adresinize Gönderilemedi!</strong>
    <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
    </div>";

            }
            return View();
        }

        
        public async Task<IActionResult> ChangePasswordAsync(string user)
        {
            if (user == null)
            {
                return BadRequest("Geçersiz İstek!");
            }

            AppUser appUser = await _userRepository.RetrieveAsync(a => a.AppUserGuid.ToString() == user);

            if (appUser == null)
            {
                return NotFound("Geçersiz Değer");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePasswordAsync(string user,string Password)
        {
            if (user == null)
            {
                return BadRequest("Geçersiz İstek!");
            }

            AppUser appUser = await _userRepository.RetrieveAsync(a => a.AppUserGuid.ToString() == user);
            if (appUser == null)
            {
                ModelState.AddModelError("", "Geçersiz Değer");
                return View();
            }

            appUser.Password = Password;
            _userRepository.Update(appUser);
            var sonuc = await _userRepository.SaveChangesAsync();

            if (sonuc > 0)
            {
                TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                        <strong>Şifreniz Güncellenmiştir! Giriş Ekranından Oturum Açabilirsiniz.</strong>
    <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
    </div>";

                return RedirectToAction(nameof(SignIn));
            }
            else
            {
                ModelState.AddModelError("", "Güncelleme Başarısız!");
                return View();
            }
            
        }






    }
}
