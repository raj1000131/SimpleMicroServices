using System.ComponentModel.DataAnnotations;

namespace Product.API.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? Title { get; set; }
    }
}
