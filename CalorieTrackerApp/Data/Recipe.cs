using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CalorieTrackerCookBookApp.Common.ValidationConstraints;

namespace CalorieTrackerCookBookApp.Data
{
    public class Recipe
    {
        [Key]
        [MaxLength(ModelIdMaxLength)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(RecipeNameMaxLength,
            ErrorMessage = RecipeNameMaxLengthExceeded)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(RecipeDescriptionMaxLength,
            ErrorMessage = RecipeDescriptionLengthExceeded)]
        public string Description { get; set; } = null!;

        [Required]
        public int CookingTime { get; set; }

        [Required]
        public int Portions { get; set; }

        [Required]
        [MaxLength(RecipePreparationStepsMaxLength,
            ErrorMessage = RecipePreparationStepsLengthExceeded)]
        public string PreparationSteps { get; set; } = null!;

        [ForeignKey(nameof(Image))]
        public Guid ImageId { get; set; }
        public Image? Image { get; set; }

        public Guid? UserId { get; set; }

        public List<Ingredient> IngredientsList { get; set; } = null!;

        public List<Like> Likes { get; set; } = null!;
    }
}
