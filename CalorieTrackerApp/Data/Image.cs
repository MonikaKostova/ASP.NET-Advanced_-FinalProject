using System.ComponentModel.DataAnnotations;
using static CalorieTrackerCookBookApp.Common.ValidationConstraints;

namespace CalorieTrackerCookBookApp.Data
{
    public class Image
    {
        [Key]
        [MaxLength(ModelIdMaxLength)]
        public Guid Id { get; set; }

        public byte[] DataBytes { get; set; } = null!;
    }
}
