using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wprac.Repository;
using wprac.Models;
 
namespace wprac.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository db;
        public EmployeeController (IEmployeeRepository db)
        {
            this.db=db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var e = db.GetAllEmployee();
            return Ok(e);
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee e)
        {
            db.AddEmployee(e);
            return Created ("Created" , e);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult FindById(int id)
        {
            var e = db.FindById(id);
            return Ok(e);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            db.DeleteEmployee(id);
            return Ok();
        }
 
        [HttpPut]
        [Route("{id}")]
        public IActionResult EditEmployee(Employee e){
            db.EditEmployee(e);
            return Ok();
        }
    }
}