using System.ComponentModel.DataAnnotations;

namespace iis_sampleconnect.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        public int Age {  get; set; }
    }
}
