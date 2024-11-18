using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static CalorieTrackerCookBookApp.Common.ValidationConstraints;

namespace CalorieTrackerCookBookApp.Data
{
    public class User : IdentityUser
    {
        
       [Key]
       [MaxLength(ModelIdMaxLength)]
       public int FullId { get; set; }


        [Required]
        public string CurrentUsername { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(UserEmailMaxLength,
            ErrorMessage = EmailMaxLengthExceeded)]
        public string UserEmail { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        // One-to-Many relationship: A User can have many Recipes
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

        // Many-to-Many relationship: A User can have many Favorites
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    }

}
