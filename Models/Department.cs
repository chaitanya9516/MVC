using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpDetails.Models
{
    public class Department
    {
        
        public byte Id { get; set; }
        [Required]
        public string Deptname { get; set; }
        public bool IsActive { get; set; }
    }
}