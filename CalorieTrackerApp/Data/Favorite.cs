using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CalorieTrackerCookBookApp.Common.ValidationConstraints;

namespace CalorieTrackerCookBookApp.Data
{
    public class Favorite
    {
       
        public string UserId { get; set; } = null!;

        public int RecipeId { get; set; }

        // Foreign Keys
       // [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        //[ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; } = null!;
        public bool IsDeleted { get; internal set; }
    }
}
