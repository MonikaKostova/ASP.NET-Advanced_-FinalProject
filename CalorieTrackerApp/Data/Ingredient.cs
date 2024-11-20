using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CalorieTrackerCookBookApp.Common.ValidationConstraints;

namespace CalorieTrackerCookBookApp.Data
{
    public class Ingredient
    {
        [Key]
        [MaxLength(ModelIdMaxLength)]
        public int Id { get; set; }

        [Required]
        [MaxLength(IngredientMaxLength)]
        public string Name { get; set; } = null!;
        public double Calories { get; set; }
        public string Macronutrients { get; set; } = null!;
        public string Quantity { get; set; } = null!;

        // Foreign Key: Links to Recipe
        [Required]
        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")] // Secondary Key (Foreign Key)
        public Recipe Recipe { get; set; } = null!;
        public bool IsDeleted { get; internal set; }
    }
}
