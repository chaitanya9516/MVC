using EmpDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpDetails.ViewModels
{
    public class NewEmployeeViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public Employee Employee { get; set; }
        public Department Department { get; set; }

    }
}