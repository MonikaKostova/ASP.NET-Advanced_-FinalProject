using CalorieTrackerCookBookApp.Models;
using CalorieTrackerCookBookApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTrackerCookBookApp.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public IActionResult Index(int recipeId)
        {
            var ingredients = _ingredientService.GetIngredientsForRecipe(recipeId);
            return View(ingredients);
        }

        [HttpGet]
        public IActionResult Create(int recipeId)
        {
            return View(new IngredientViewModel { RecipeId = recipeId });
        }

        [HttpPost]
        public IActionResult Create(IngredientViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ingredientService.AddIngredientToRecipe(model);
                return RedirectToAction("Index", new { recipeId = model.RecipeId });
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _ingredientService.DeleteIngredient(id);
            return RedirectToAction("Index");
        }
    }
}
