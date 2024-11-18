using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerCookBookApp.Models
{
    public class RecipeEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string RecipeName { get; set; } = null!;

        [Required]
        public string RecipeDescription { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;

        public string Ingredients { get; set; } = null!;

        public string ImageUrls { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
