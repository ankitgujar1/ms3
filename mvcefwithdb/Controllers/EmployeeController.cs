using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcefwithdb.Data;
using mvcefwithdb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvcefwithdb.Controllers
{
    // [Route("[controller]")]
    public class EmployeeController : Controller
    {
        
        // CodeFirstDbContext db = new CodeFirstDbContext();

        private CodeFirstDbContext db;
        
        public EmployeeController(CodeFirstDbContext db){
            this.db=db;
        }

        public IActionResult Index()
        {
            var empList = db.Employees.Include("Department");
            // ViewBag.l=empList;
            ViewBag.count = db.Employees.Count();
            ViewBag.maxsalary = db.Employees.Max(e => e.Salary);
            return View(empList);
        }
        public IActionResult Create()
        {
            var depList = db.Departments;
            SelectList s1 = new SelectList(depList, "DepartmentId", "DepartmentName");
            ViewBag.depList = s1;

            //for partial view
            var emp=db.Employees;
            ViewBag.empList=emp;

            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            {
                db.Employees.Add(emp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var depList = db.Departments;
            SelectList s1 = new SelectList(depList, "DepartmentId", "DepartmentName");
            ViewBag.depList = s1;
            var emp = db.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (emp != null)
            {
                return View(emp);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Employee e){
            db.Employees.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var depList = db.Departments;
            SelectList s1 = new SelectList(depList, "DepartmentId", "DepartmentName");
            ViewBag.depList = s1;
            var emp = db.Employees.Find(id);
            if (emp != null)
            {
                return View(emp);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(Employee empobj)
        {
            db.Update(empobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id){
            var e=db.Employees.Find(id);
            return View(e);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}