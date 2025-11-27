using LanguLexi.DataAccess.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LanguLexi.Core.Entities;

namespace LanguLexi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy ="AdminPolicy")]
    public class AppUsersController : Controller
    {
        private readonly IRepository<AppUser> _repository;

        public AppUsersController(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        
        public async Task<IActionResult> Index()
        {
            var AppUsersList = await _repository.RetrieveAllAsync();
            return View(AppUsersList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }

            var appUser = await _repository.RetrieveAsync(a => a.Id == id);

            if (appUser == null)
            {
                return NotFound();
            }
            
            return View(appUser);
        }



    }
}
