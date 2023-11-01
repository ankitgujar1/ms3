using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using p.Models;
namespace p.Controllers
{
    // [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        EmpDbContext db=new EmpDbContext();

        // [Route("/")]
        // [Route("")]
        public IActionResult Index()
        {
            var emp=db.Employees.FirstOrDefault(e=>e.EmployeeName.StartsWith("A"));
            return View(emp);
        }
        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee e){
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        
        

        public IActionResult Edit(int id){
            var e=db.Employees.Find(id);
            if(e!=null){
                return View(e);
            }
            else return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Edit(Employee e){
            db.Update(e);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id){
            var e=db.Employees.Find(id);
            if(e!=null){
                db.Employees.Remove(e);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        

        [Route("Employee/AddNum/{n1}/{n2}")]
        
        public int AddNum(int n1,int n2){
            return n1+n2;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}