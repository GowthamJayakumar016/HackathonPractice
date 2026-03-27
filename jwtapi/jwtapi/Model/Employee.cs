using System.ComponentModel.DataAnnotations;

namespace jwtapi.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }

        public string? DEpartment { get; set; }
    }
}
