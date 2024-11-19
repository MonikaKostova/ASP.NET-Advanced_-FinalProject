using CalorieTrackerCookBookApp.Data;
using CalorieTrackerCookBookApp.Models;
using CalorieTrackerCookBookApp.Services.Interfaces;

namespace CalorieTrackerCookBookApp.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to get all comments
        public IEnumerable<CommentViewModel> GetAllComments()
        {
            return _context.Comments
                           .Where(c => !c.IsDeleted)
                           .Select(c => new CommentViewModel
                           {
                               Id = c.Id,
                               Content = c.Content,
                               AuthorId = c.AuthorId,
                               RecipeId = c.RecipeId,
                               IsApproved = c.IsApproved
                           })
                           .ToList();
        }

        // Method to get a specific comment by ID
        public CommentViewModel GetCommentById(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                throw new Exception("Comment not found");
            }

            return new CommentViewModel
            {
                Id = comment.Id,
                Content = comment.Content,
                AuthorId = comment.AuthorId,
                RecipeId = comment.RecipeId,
                IsApproved = comment.IsApproved
            };
        }

        // New Method: Get comments for a specific recipe
        public IEnumerable<CommentViewModel> GetCommentsForRecipe(int recipeId)
        {
            return _context.Comments
                           .Where(c => c.RecipeId == recipeId && !c.IsDeleted)
                           .Select(c => new CommentViewModel
                           {
                               Id = c.Id,
                               Content = c.Content,
                               AuthorId = c.AuthorId,
                               RecipeId = c.RecipeId,
                               IsApproved = c.IsApproved
                           })
                           .ToList();
        }

        // Method to create a new comment
        public void CreateComment(CommentCreateViewModel model)
        {
            var newComment = new Comment
            {
                Content = model.Content,
                AuthorId = model.AuthorId,
                RecipeId = model.RecipeId,
                IsApproved = false,
                IsDeleted = false
            };

            _context.Comments.Add(newComment);
            _context.SaveChanges();
        }

        // Method to get comment data for editing
        public CommentViewModel GetCommentForEdit(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                throw new Exception("Comment not found");
            }

            return new CommentViewModel
            {
                Id = comment.Id,
                Content = comment.Content,
                IsApproved = comment.IsApproved
            };
        }

        // Method to update a comment
        public void UpdateComment(CommentViewModel model)
        {
            var comment = _context.Comments.Find(model.Id);
            if (comment == null)
            {
                throw new Exception("Comment not found");
            }

            comment.Content = model.Content;
            comment.IsApproved = model.IsApproved;

            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        // New Method: Approve a comment
        public void ApproveComment(int commentId)
        {
            var comment = _context.Comments.Find(commentId);
            if (comment == null)
            {
                throw new Exception("Comment not found");
            }

            comment.IsApproved = true;
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        // Method to delete a comment
        public void DeleteComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                throw new Exception("Comment not found");
            }

            comment.IsDeleted = true;
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }
    }
}
