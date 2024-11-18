using Microsoft.AspNetCore.Mvc;

namespace CalorieTrackerCookBookApp.Controllers
{
    public class IngredientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
