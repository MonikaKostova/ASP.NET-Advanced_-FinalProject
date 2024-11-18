using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerCookBookApp.Models
{
    public class UserCreateViewModel
    {
        [Required]
        public string CurrentUsername { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
