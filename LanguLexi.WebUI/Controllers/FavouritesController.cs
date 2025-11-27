using Microsoft.AspNetCore.Mvc;

namespace LanguLexi.WebUI.Controllers
{
    public class FavouritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
