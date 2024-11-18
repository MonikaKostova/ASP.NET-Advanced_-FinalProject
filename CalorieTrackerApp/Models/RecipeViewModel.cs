namespace CalorieTrackerCookBookApp.Models;

using System.ComponentModel.DataAnnotations;
using static CalorieTrackerCookBookApp.Common.ValidationConstraints;

    public class RecipeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string RecipeName { get; set; } = null!;

        [Required]
        public string RecipeDescription { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;

        public string OwnerId { get; set; } = null!;
        public string OwnerName { get; set; } = null!; // To display the owner's name

        public List<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();
        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
    }

