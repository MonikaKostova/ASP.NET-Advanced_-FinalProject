using Microsoft.AspNetCore.Mvc;

namespace CalorieTrackerCookBookApp.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
