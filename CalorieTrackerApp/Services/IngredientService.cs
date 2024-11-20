using CalorieTrackerCookBookApp.Data;
using CalorieTrackerCookBookApp.Models;
using CalorieTrackerCookBookApp.Services.Interfaces;

namespace CalorieTrackerCookBookApp.Services
{
    public class IngredientService 
    {
        private readonly ApplicationDbContext _context;

        public IngredientService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all ingredients for a specific recipe
        public List<IngredientViewModel> GetIngredientsForRecipe(int recipeId)
        {
            var ingredients = _context.Ingredients
                .Where(i => i.RecipeId == recipeId && !i.IsDeleted)
                .Select(i => new IngredientViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Calories = i.Calories,
                    Macronutrients = i.Macronutrients,
                    Quantity = i.Quantity
                }).ToList();

            return ingredients;
        }

        // Add an ingredient to a recipe
        public void AddIngredientToRecipe(IngredientViewModel ingredient)
        {
            if (ingredient == null) throw new ArgumentNullException(nameof(ingredient));

            var newIngredient = new Ingredient
            {
                Name = ingredient.Name,
                Calories = ingredient.Calories,
                Macronutrients = ingredient.Macronutrients,
                Quantity = ingredient.Quantity,
                RecipeId = ingredient.RecipeId
            };

            _context.Ingredients.Add(newIngredient);
            _context.SaveChanges();
        }

        // Delete an ingredient by its ID
        public void DeleteIngredient(int ingredientId)
        {
            var ingredient = _context.Ingredients.FirstOrDefault(i => i.Id == ingredientId && !i.IsDeleted);

            if (ingredient == null)
            {
                throw new Exception("Ingredient not found");
            }

            ingredient.IsDeleted = true;
            _context.Ingredients.Update(ingredient);
            _context.SaveChanges();
        }
    }
}

