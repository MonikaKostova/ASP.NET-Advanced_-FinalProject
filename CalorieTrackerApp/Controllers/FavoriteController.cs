using Microsoft.AspNetCore.Mvc;

namespace CalorieTrackerCookBookApp.Controllers
{
    public class FavoriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
