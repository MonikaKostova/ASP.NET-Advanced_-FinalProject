using System.ComponentModel.DataAnnotations;
using static CalorieTrackerCookBookApp.Common.ValidationConstraints;

namespace CalorieTrackerCookBookApp.Models
{
    public class IngredientViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(IngredientMaxLength)]
        public string Name { get; set; } = null!;

        public double Calories { get; set; }
        public string Macronutrients { get; set; } = null!;
        public string Quantity { get; set; } = null!;
        public int RecipeId { get; set; }
        public string RecipeName { get; set; } = null!; // To display recipe name
    }
}

