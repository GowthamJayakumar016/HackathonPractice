using System.ComponentModel.DataAnnotations;

namespace GroceryShopApp.Models
{
    public class Product
    {
        public int Id { get; set; }   // Primary Key

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string? Category { get; set; }
    }
}
