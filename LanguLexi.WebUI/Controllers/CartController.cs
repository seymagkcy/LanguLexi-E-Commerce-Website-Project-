using Microsoft.AspNetCore.Mvc;
using LanguLexi.DataAccess.Abstract;
using LanguLexi.DataAccess.Concrete;
using LanguLexi.Core.Entities;

namespace LanguLexi.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<Order> _orderRepository;

        public CartController(IRepository<Course> courseRepository, IRepository<AppUser> userRepository, IRepository<Order> orderRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
