using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CalorieTrackerCookBookApp.Common.ValidationConstraints;

namespace CalorieTrackerCookBookApp.Data
{
    public class RecipeImage
    {
        [Key]
        [MaxLength(ModelIdMaxLength)]
        public int Id { get; set; }

        public string? Url { get; set; }
        // Foreign Key: Links to Recipe
        [Required]
        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")] // Secondary Key (Foreign Key)
        public Recipe Recipe { get; set; } = null!;
        public bool IsDeleted { get; internal set; }
    }
}
