using EmpDetails.Models;
using EmpDetails.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpDetails.Controllers
{
    public class DepartmentsController : Controller
    {
        public ApplicationDbContext _context;
        public DepartmentsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Departments
       
        public ActionResult DepartmentDetailsPage()
        {
            var department = _context.Departments.ToList();
            return View(department);
        }
        public ActionResult New()
        {
             var department = _context.Departments.ToList();
            var viewModel = new NewEmployeeViewModel()
            {
                Departments = department

            };
            return View("DepartmentForm",viewModel);
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (department.Id==0 )
            {
                _context.Departments.Add(department);
            }
            else
            {
                var departmentInDb = _context.Departments.Single(c => c.Id == department.Id);
                departmentInDb.Deptname = department.Deptname;
                departmentInDb.IsActive = department.IsActive;
            }
            _context.SaveChanges();
            return RedirectToAction("DepartmentDetailsPage", "Departments");
            
        }
        public ActionResult Edit(int id)
        {
            var department= _context.Departments.SingleOrDefault(c => c.Id == id);
            if (department == null)
                return HttpNotFound();
            var viewModel = new NewEmployeeViewModel
            {
                Department=department
            };
            return View("DepartmentForm",viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id, Department department)
        {
            var departmentInDb = _context.Departments.Single(c => c.Id == department.Id);
            _context.Departments.Remove(departmentInDb);
            _context.SaveChanges();
            return RedirectToAction("DepartmentDetailsPage", "Departments");
        }

    }
}