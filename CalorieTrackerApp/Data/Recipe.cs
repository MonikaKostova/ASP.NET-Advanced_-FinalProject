using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CalorieTrackerCookBookApp.Common.ValidationConstraints;

namespace CalorieTrackerCookBookApp.Data
{
    public class Recipe
    {
        [Key]
        [MaxLength(ModelIdMaxLength)]
        public int Id { get; set; }

        [Required]
        [MaxLength(RecipeNameMaxLength,
            ErrorMessage = RecipeNameMaxLengthExceeded)]
        public string RecipeName { get; set; } = null!;

        [Required]
        [MaxLength(RecipeDescriptionMaxLength,
            ErrorMessage = RecipeDescriptionLengthExceeded)]
        public string RecipeDescription { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;

        // Foreign Key: Links to User
        [Required]
        public string OwnerId { get;  set; } = null!;

        [ForeignKey("OwnerId")] // Foreign Key
        public User Owner { get; set; } = null!;

        // One-to-Many relationship: A Recipe can have many Images
        public ICollection<RecipeImage> Images { get; set; } = new List<RecipeImage>();
        
        // One-to-Many relationship: A Recipe can have many Ingredients

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        
        // One-to-Many relationship: A Recipe can have many Comments
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

        public bool IsDeleted { get; set; } = false;
    }
}
