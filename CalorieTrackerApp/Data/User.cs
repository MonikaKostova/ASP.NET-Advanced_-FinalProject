using System.ComponentModel.DataAnnotations;
using static CalorieTrackerCookBookApp.Common.ValidationConstraints;

namespace CalorieTrackerCookBookApp.Data
{
    public class User
    {
        public User()
        {
            this.Recipes = new List<Recipe>();
            this.LikedRecipes = new List<Like>();
        }

        [Key]
        [MaxLength(ModelIdMaxLength)]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(UserEmailMaxLength,
            ErrorMessage = EmailMaxLengthExceeded)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public List<Recipe> Recipes { get; set; }

        public List<Like> LikedRecipes { get; set; }
    }
   
}
