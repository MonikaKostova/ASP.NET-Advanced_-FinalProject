using Microsoft.AspNetCore.Mvc;

namespace CalorieTrackerCookBookApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
