using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmpApi.Repository;

namespace EmpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        EmployeeRepository repo=new EmployeeRepository();

        [HttpGet]
        public IActionResult Get(){
            var e=repo.GetAllEmp();
            return Ok(e);
        }
    }
}