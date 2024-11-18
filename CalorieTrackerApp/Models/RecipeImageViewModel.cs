namespace CalorieTrackerCookBookApp.Models
{
    public class RecipeImageViewModel
    {
        public int Id { get; set; }
        public string? Url { get; set; }

        public int RecipeId { get; set; }
        public string RecipeName { get; set; } = null!; // To display recipe name
    }
}
