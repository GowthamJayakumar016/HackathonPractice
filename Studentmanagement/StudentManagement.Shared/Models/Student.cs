using System.ComponentModel.DataAnnotations;

namespace Studentmanagement.Models
{
    public class Student
    {
        [Key]
        public int Id {  get; set; }
      
        public string? Firstname {  get; set; }
      
        public  string? Middlename {  get; set; }
       
        public string? Lastname { get; set; }
        public string? Fullname => $"{Firstname} {Middlename} {Lastname}";
        public string? EmailAddress { get; set; }

        
        public string? Password {  get; set; }
        public int PhoneNumber {  get; set; }   
        
        public string? Country {  get; set; }

    }
}
