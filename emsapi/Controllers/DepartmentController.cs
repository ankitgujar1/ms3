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

        [HttpPost]
        [Route("AddDept")]
        public IActionResult Post(Department d){
            repo.AddDept(d);
            return Ok();
        }

        [HttpPut]
        [Route("EditDept/{id}")]
        public IActionResult Put(Department d){
            repo.EditDept(d);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteDept/{id}")]
        public IActionResult Delete(int id){
            repo.DeleteDept(id);
            return Ok();
        }

        [HttpGet]
        [Route("FindDept/{id}")]
        public IActionResult Get(int id){
            // repo.FindDept(id);
            return Ok(repo.FindDept(id));
        }
        
    }
}