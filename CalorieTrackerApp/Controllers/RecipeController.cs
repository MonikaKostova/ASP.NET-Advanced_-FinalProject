using CalorieTrackerCookBookApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTrackerCookBookApp.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public IActionResult Index()
        {
            var recipes = _recipeService.GetAllRecipes();
            return View(recipes);
        }

        public IActionResult Details(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RecipeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _recipeService.CreateRecipe(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recipe = _recipeService.GetRecipeForEdit(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(RecipeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _recipeService.UpdateRecipe(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _recipeService.DeleteRecipe(id);
            return RedirectToAction("Index");
        }
    }
}
