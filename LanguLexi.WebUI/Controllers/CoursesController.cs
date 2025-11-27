using Microsoft.AspNetCore.Mvc;

namespace LanguLexi.WebUI.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
