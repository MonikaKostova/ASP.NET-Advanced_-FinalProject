using CalorieTrackerCookBookApp.Models;

namespace CalorieTrackerCookBookApp.Services.Interfaces
{
    public interface IFavoriteService
    {
        IEnumerable<FavoriteViewModel> GetAllFavorites();
        IEnumerable<FavoriteViewModel> GetFavoritesForUser(string userId);
        void AddToFavorites(FavoriteViewModel model);
        void RemoveFromFavorites(int recipeId, string userId);
    }
}