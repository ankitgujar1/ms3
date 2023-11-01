using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using U.Models;

namespace U.Controllers
{
    // [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        EDBContext db = new EDBContext();

        public IActionResult Index()
        {
            var i = db.Employees;
            return View(i);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var emp = db.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
            // return RedirectToAction("Index");
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            var emp = db.Employees.Find(id);
            if (emp != null)
            {
                return View(emp);
            }
            else  return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            db.Update(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}