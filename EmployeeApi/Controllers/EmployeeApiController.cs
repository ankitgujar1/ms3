using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeApiController : ControllerBase
    {
    
        private ApiDbContext db;

        public EmployeeApiController(ApiDbContext db){
            this.db=db;
        }

        [HttpGet]
        public IActionResult Get(){
            var e=db.Employees;
            return Ok(e);
        }

        [HttpPost]
        public IActionResult Post(Employee emp){
            db.Employees.Add(emp);
            db.SaveChanges();
            return Ok();
        }
    }
}