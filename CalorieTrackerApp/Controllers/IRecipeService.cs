using CalorieTrackerCookBookApp.Models;

namespace CalorieTrackerCookBookApp.Controllers
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