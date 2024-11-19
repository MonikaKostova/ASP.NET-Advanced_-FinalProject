using CalorieTrackerCookBookApp.Data;
using CalorieTrackerCookBookApp.Models;
using CalorieTrackerCookBookApp.Services.Interfaces;

namespace CalorieTrackerCookBookApp.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly ApplicationDbContext _context;

        public FavoriteService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to get all favorites
        public IEnumerable<FavoriteViewModel> GetAllFavorites()
        {
            return _context.Favorites
                           .Where(f => !f.IsDeleted)
                           .Select(f => new FavoriteViewModel
                           {
                               UserId = f.UserId,
                               RecipeId = f.RecipeId,
                               RecipeName = f.Recipe.RecipeName
                           })
                           .ToList();
        }

        // New Method: Get all favorites for a specific user
        public IEnumerable<FavoriteViewModel> GetFavoritesForUser(string userId)
        {
            return _context.Favorites
                           .Where(f => f.UserId == userId && !f.IsDeleted)
                           .Select(f => new FavoriteViewModel
                           {
                               UserId = f.UserId,
                               RecipeId = f.RecipeId,
                               RecipeName = f.Recipe.RecipeName
                           })
                           .ToList();
        }

        // New Method: Add a recipe to favorites
        public void AddToFavorites(FavoriteViewModel model)
        {
            var newFavorite = new Favorite
            {
                UserId = model.UserId,
                RecipeId = model.RecipeId,
                IsDeleted = false
            };

            _context.Favorites.Add(newFavorite);
            _context.SaveChanges();
        }

        // New Method: Remove a recipe from favorites
        public void RemoveFromFavorites(int recipeId, string userId)
        {
            var favorite = _context.Favorites
                                   .FirstOrDefault(f => f.RecipeId == recipeId && f.UserId == userId);
            if (favorite == null)
            {
                throw new Exception("Favorite not found");
            }

            favorite.IsDeleted = true;
            _context.Favorites.Update(favorite);
            _context.SaveChanges();
        }
    }
}
