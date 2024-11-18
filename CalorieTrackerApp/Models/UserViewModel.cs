using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerCookBookApp.Models
{
    public class UserViewModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        public string CurrentUsername { get; set; } = null!;

        [Required]
        public string UserEmail { get; set; } = null!;
        public List<RecipeViewModel> Recipes { get; set; } = new List<RecipeViewModel>();
        public List<FavoriteViewModel> Favorites { get; set; } = new List<FavoriteViewModel>();
    }
}
