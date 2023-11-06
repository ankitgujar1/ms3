using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using emsapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace emsapi.Controllers
{
    // [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        IDepartment repo;
        public DepartmentController(IDepartment _repo)
        {
            this.repo = _repo;
        }
 
        [HttpGet]
        [Route("ListDept")]
        public IActionResult GetDept()
        {
            var data = repo.GetDepartments();
            return Ok(data);
        }
        
    }
}