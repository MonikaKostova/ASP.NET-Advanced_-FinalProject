namespace CalorieTrackerCookBookApp.Models
{
    public class FavoriteViewModel
    {
        public string UserId { get; set; } = null!;
        public int RecipeId { get; set; }

        public string UserName { get; set; } = null!;  // To display the user name
        public string RecipeName { get; set; } = null!; // To display the recipe name
    }
}
