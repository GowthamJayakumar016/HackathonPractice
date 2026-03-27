using System.ComponentModel.DataAnnotations;

namespace EmployeeApi1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Department {  get; set; }
    }
}
