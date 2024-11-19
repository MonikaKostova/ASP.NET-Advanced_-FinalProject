using CalorieTrackerCookBookApp.Models;
using CalorieTrackerCookBookApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTrackerCookBookApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index(int recipeId)
        {
            var comments = _commentService.GetCommentsForRecipe(recipeId);
            return View(comments);
        }

        [HttpGet]
        public IActionResult Create(int recipeId)
        {
            return View(new CommentCreateViewModel { RecipeId = recipeId });
        }

        [HttpPost]
        public IActionResult Create(CommentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _commentService.CreateComment(model);
                return RedirectToAction("Index", new { recipeId = model.RecipeId });
            }
            return View(model);
        }

        public IActionResult Approve(int id)
        {
            _commentService.ApproveComment(id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _commentService.DeleteComment(id);
            return RedirectToAction("Index");
        }
    }
}
