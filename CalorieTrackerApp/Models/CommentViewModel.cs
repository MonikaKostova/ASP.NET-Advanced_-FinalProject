using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerCookBookApp.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = null!;

        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }

        // Foreign Keys
        public string AuthorId { get; set; } = null!;
        public string AuthorName { get; set; } = null!; // To display author name

        public int RecipeId { get; set; }
    }
}
