using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTrackerCookBookApp.Data
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = null!;
       
        public bool IsApproved { get; set; }

        public bool IsDeleted { get; set; } = false;

        // Foreign Keys: Links to User and Recipe
        [Required]
        public string AuthorId { get; set; } = null!;

        [ForeignKey("AuthorId")] 
        public User Author { get; set; } = null!;

        [Required]
        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")] 
        public Recipe Recipe { get; set; } = null!;
    }
}
