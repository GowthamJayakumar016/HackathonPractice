using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Grocery
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Price { get; set; }

    }
}
