using CalorieTrackerCookBookApp.Models;

namespace CalorieTrackerCookBookApp.Controllers
{
    public interface ICommentService
    {
        IEnumerable<CommentViewModel> GetAllComments();
        CommentViewModel GetCommentById(int id);
        IEnumerable<CommentViewModel> GetCommentsForRecipe(int recipeId); 
        void CreateComment(CommentCreateViewModel model);
        CommentViewModel GetCommentForEdit(int id);
        void UpdateComment(CommentViewModel model);
        void DeleteComment(int id);
        void ApproveComment(int commentId); 
    }
}