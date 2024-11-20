using CalorieTrackerCookBookApp.Data;
using CalorieTrackerCookBookApp.Models;
using CalorieTrackerCookBookApp.Services.Interfaces;
using CalorieTrackerCookBookApp.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace CalorieTrackerCookBookApp.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RecipeViewModel> GetAllRecipes()
        {
            return _context.Recipes
                .Where(r => !r.IsDeleted)
                .Select(r => new RecipeViewModel
                {
                    Id = r.Id,
                    RecipeName = r.RecipeName,
                    RecipeDescription = r.RecipeDescription,
                    Category = r.Category,
                    OwnerId = r.OwnerId,
                    OwnerName = r.Owner.UserName ?? string.Empty,
                    Ingredients = r.Ingredients.Select(i => new IngredientViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Quantity = i.Quantity
                    }).ToList(),
                    Comments = r.Comments.Select(c => new CommentViewModel
                    {
                        Id = c.Id,
                        Content = c.Content,
                        AuthorName = c.Author.UserName ?? string.Empty
                    }).ToList()
                }).ToList();
        }

        public RecipeViewModel GetRecipeById(int id)
        {
            var recipe = _context.Recipes
                .Where(r => !r.IsDeleted && r.Id == id)
                .Select(r => new RecipeViewModel
                {
                    Id = r.Id,
                    RecipeName = r.RecipeName,
                    RecipeDescription = r.RecipeDescription,
                    Category = r.Category,
                    OwnerId = r.OwnerId,
                    OwnerName = r.Owner.UserName ?? string.Empty,
                    Ingredients = r.Ingredients.Select(i => new IngredientViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Quantity = i.Quantity
                    }).ToList(),
                    Comments = r.Comments.Select(c => new CommentViewModel
                    {
                        Id = c.Id,
                        Content = c.Content,
                        AuthorName = c.Author.UserName ?? string.Empty
                    }).ToList()
                }).FirstOrDefault();

            if (recipe == null)
                throw new Exception("Recipe not found");

            return recipe;
        }

        public RecipeEditViewModel GetRecipeForEdit(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => !r.IsDeleted && r.Id == id);

            if (recipe == null)
                throw new Exception("Recipe not found");

            return new RecipeEditViewModel
            {
                Id = recipe.Id,
                RecipeName = recipe.RecipeName,
                RecipeDescription = recipe.RecipeDescription,
                Category = recipe.Category,
                Ingredients = string.Join(", ", recipe.Ingredients.Select(i => i.Name))
            };
        }

        public void CreateRecipe(RecipeCreateViewModel model)
        {
            var recipe = new Recipe
            {
                RecipeName = model.RecipeName,
                RecipeDescription = model.RecipeDescription,
                Category = model.Category,
                OwnerId = "OwnerIdPlaceholder", 
                Ingredients = model.Ingredients
                    .Split(',')
                    .Select(i => new Ingredient
                    {
                        Name = i.Trim(),
                        Quantity = "1 unit" 
                    })
                    .ToList()
            };

            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void UpdateRecipe(RecipeEditViewModel model)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == model.Id && !r.IsDeleted);

            if (recipe == null)
                throw new Exception("Recipe not found");

            recipe.RecipeName = model.RecipeName;
            recipe.RecipeDescription = model.RecipeDescription;
            recipe.Category = model.Category;

            // Update ingredients
            recipe.Ingredients.Clear();
            recipe.Ingredients = model.Ingredients
                .Split(',')
                .Select(i => new Ingredient
                {
                    Name = i.Trim(),
                    Quantity = "1 unit"
                })
                .ToList();

            _context.SaveChanges();
        }

        public void DeleteRecipe(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id && !r.IsDeleted);

            if (recipe == null)
                throw new Exception("Recipe not found");

            recipe.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}

