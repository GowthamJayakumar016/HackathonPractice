using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentManagement.Shared.Models
{
    public class SystemCode
    {
       [Key]
        public int Id { get; set; }
        public string? Code {  get; set; }
        public string? Description { get; set; }
    }
}
