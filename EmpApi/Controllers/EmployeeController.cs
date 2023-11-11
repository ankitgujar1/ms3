using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmpApi.Repository;
using EmpApi.Models;
using log4net;
using log4net.Config;

namespace EmpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // EmployeeRepository repo = new EmployeeRepository();
        private readonly ILog _logger;
 
        private IEmployeeRepository repo;
        public EmployeeController(IEmployeeRepository repository ,ILog logger)  
        {
            repo = repository;
            _logger=logger;
        }
 
        [HttpGet]
        public IActionResult Get()
        {
            var empList = repo.GetAllEmployees();
            _logger.Info("Employee Data fetched from Database");
            _logger.Error("This is an error log");
            return Ok(empList);
        }
 
        [HttpPost]
        public IActionResult Post(Employee newemp)
        {
            var emp = repo.AddEmployee(newemp);
            // return CreatedAtAction ("Get" , new {id = emp.EmployeeId} , emp);
            return Ok(emp);
 
        }
 
    }
}