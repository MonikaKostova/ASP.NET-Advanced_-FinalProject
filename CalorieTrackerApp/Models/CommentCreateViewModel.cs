using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerCookBookApp.Models
{
    public class CommentCreateViewModel
    {
        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public int RecipeId { get; set; }

        public string AuthorId { get; set; } = null!;
    }
}
