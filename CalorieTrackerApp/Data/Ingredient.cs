using System.ComponentModel.DataAnnotations;
using static CalorieTrackerCookBookApp.Common.ValidationConstraints;

namespace CalorieTrackerCookBookApp.Data
{
    public class Ingredient
    {
        [Key]
        [MaxLength(ModelIdMaxLength)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(IngredientMaxLength)]
        public string NameAndQuantity { get; set; }
    }
}
