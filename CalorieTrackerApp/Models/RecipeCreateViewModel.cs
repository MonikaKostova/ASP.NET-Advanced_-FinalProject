using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerCookBookApp.Models
{
    public class RecipeCreateViewModel
    {
        [Required]
        public string RecipeName { get; set; } = null!;

        [Required]
        public string RecipeDescription { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;

        [Required]
        public string Ingredients { get; set; } = null!; 

        [Required]
        public string ImageUrls { get; set; } = null!;  
    }
}
