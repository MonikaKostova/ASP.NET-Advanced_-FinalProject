using CalorieTrackerCookBookApp.Data;
using CalorieTrackerCookBookApp.Models;

namespace CalorieTrackerCookBookApp.Services.Interfaces
{
    public interface IIngredientService
    {
        // Get all ingredients for a specific recipe
        List<IngredientViewModel> GetIngredientsForRecipe(int recipeId);

        // Add an ingredient to a recipe
        void AddIngredientToRecipe(IngredientViewModel ingredient);

        // Delete an ingredient by its ID
        void DeleteIngredient(int ingredientId);
    }
}