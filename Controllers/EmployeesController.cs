using EmpDetails.Models;
using EmpDetails.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmpDetails.Controllers
{
    public class EmployeesController : Controller
    {
        public ApplicationDbContext _context;
        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Employees
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var r = getuser(employee.Email, employee.Password);
                if (r != null)
                {
                    Session["UserId"] = r.Email;
                    FormsAuthentication.SetAuthCookie(r.Email, false);
                    return RedirectToAction("EmployeeDetailsPage", "Employees");
                }
                else
                {
                    TempData["msg"] = "Invalid Credentials";
                    var emp = new Employee();
                    emp.Department = new Department();
                    emp.Department.IsActive = true;
                    return View("Index", emp);
                }
            }

            return View("Index");
        }
        public Employee getuser(string emailId, string password = "")
        {
            List<Employee> res;
            if (password != "")
                res = _context.Employees.Where(x => x.Email == emailId && x.Password == password).ToList();
            else
                res = _context.Employees.Where(x => x.Email == emailId).ToList();
            return (res != null && res.Count > 0) ? (Employee)res[0] : null;
        }
        public ActionResult EmployeeDetailsPage()
        {
            List<Employee> employee = _context.Employees.Include(c=>c.Department).ToList();
            return View(employee);
        }
        public ActionResult New()
        {
            var department = _context.Departments.ToList();
            var viewModel = new NewEmployeeViewModel()
            {
                Departments = department

            };
            return View("EmployeeForm",viewModel);
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            
            if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
            }
            else
            {
                var employeeInDb = _context.Employees.Single(c => c.Id == employee.Id);
                employeeInDb.Name = employee.Name;
                employeeInDb.Email = employee.Email;
                employeeInDb.Password = employee.Password;
                employeeInDb.Salary = employee.Salary;
                employeeInDb.IsActive = employee.IsActive;
                employeeInDb.DepartmentId = employee.DepartmentId;
            }

            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
                return RedirectToAction("EmployeeDetailsPage", "Employees");
        }
        
        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id ==id);
            if (employee == null)
                return HttpNotFound();
            var viewModel = new NewEmployeeViewModel()
            {
                Employee = employee,
                Departments = _context.Departments.ToList()
            };

            return View("EmployeeForm",viewModel);
        }
        [HttpPost]
        public ActionResult Delete(int id,Employee employee)
        {
            var employeeInDb = _context.Employees.Single(c => c.Id==employee.Id);
            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();
            return RedirectToAction("EmployeeDetailsPage", "Employees");
        }

        public ActionResult ForgotPassword(Employee employee)
        {
            var emp = getuser(employee.Email);
            return View(emp != null ? emp : new Employee() { Password = "" });
        }
       









        }
}