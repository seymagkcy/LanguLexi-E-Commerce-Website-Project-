using Microsoft.AspNetCore.Mvc;

namespace LanguLexi.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
