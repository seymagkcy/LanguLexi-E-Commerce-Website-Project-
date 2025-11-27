using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanguLexi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy ="AdminPolicy")]
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
