using CalorieTrackerCookBookApp.Models;

namespace CalorieTrackerCookBookApp.Services.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<RecipeViewModel> GetAllRecipes();
        RecipeViewModel GetRecipeById(int id);
        RecipeEditViewModel GetRecipeForEdit(int id);
        void CreateRecipe(RecipeCreateViewModel model);
        void UpdateRecipe(RecipeEditViewModel model);
        void DeleteRecipe(int id);
    }
}