using CalorieTrackerCookBookApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTrackerCookBookApp.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        public IActionResult Index(string userId)
        {
            var favorites = _favoriteService.GetFavoritesForUser(userId);
            return View(favorites);
        }

        public IActionResult Add(string userId, int recipeId)
        {
            var favoriteModel = new FavoriteViewModel
            {
                UserId = userId,
                RecipeId = recipeId
            };

            _favoriteService.AddToFavorites(favoriteModel);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromFavorites(string userId, int recipeId)
        {
            _favoriteService.RemoveFromFavorites(recipeId, userId);
            return RedirectToAction("Index", new { userId });
        }
    }
}
