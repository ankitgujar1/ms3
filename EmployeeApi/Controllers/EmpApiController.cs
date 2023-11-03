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
    public class EmpApiController : ControllerBase
    {
    
        private ApiDbContext db;

        public EmpApiController(ApiDbContext db){
            this.db=db;
        }

        [HttpGet]
        public IActionResult Get(){
            var e=db.Employees;
            return Ok(e);
        }

        [HttpPost]
        public IActionResult Post(Employee emp){
            var e=db.Employees.Add(emp);
            return Ok(e);
        }
    }
}