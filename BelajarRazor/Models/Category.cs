using System.ComponentModel.DataAnnotations;

namespace BelajarRazor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Display Order")]
        [Range(1,100,ErrorMessage = "Just From 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}
