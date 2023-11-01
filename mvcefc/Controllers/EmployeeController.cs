using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using mvcefc.Models;
namespace mvcefc.Controllers
{
    //find only search on primary key but firstordefault search on any column(syntax uses linq)
   
    public class EmployeeController : Controller
    {
    
        private readonly ILogger<EmployeeController> _logger;
 
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }
 
        public IActionResult Index()
        {
            return View();
        }
 
        [HttpGet]
        public IActionResult Create()
        {
            List<Department> l=new List<Department>(){
                new Department{DepartmentId=1,DepartmentName="HR"},
                new Department{DepartmentId=1,DepartmentName="Sales"},
                new Department{DepartmentId=1,DepartmentName="Accounts"}
            };

            SelectList sl=new SelectList(l,"DepartmentId","DepartmentName");
            ViewBag.Data=sl;
            return View();
        }
 
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            List<Department> l=new List<Department>(){
                new Department{DepartmentId=1,DepartmentName="HR"},
                new Department{DepartmentId=1,DepartmentName="Sales"},
                new Department{DepartmentId=1,DepartmentName="Accounts"}
            };

            SelectList sl=new SelectList(l,"DepartmentId","DepartmentName");
            ViewBag.Data=sl;
            if(ModelState.IsValid)
            {
                // database codes come here
                ModelState.Clear();
                ViewBag.message ="Employee Added.";
            }
            else
            {
                ViewBag.message="Invalid Input.";
            }
           
            return View();
 
        }
 
 
 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}