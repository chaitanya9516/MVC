using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpDetails.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
        public Department Department { get; set; }
        public byte DepartmentId { get; set; }
        public string LogInMessage { get; set; }

        
    }
}