using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers
{

   
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        //methods name can only be Get, Post, 
         private static List<Employee> l = new List<Employee>{
            new Employee{EmployeeId=1,EmployeeName="ankit",Salary=234},
            new Employee{EmployeeId=2,EmployeeName="mustafa",Salary=98765},
            new Employee{EmployeeId=3,EmployeeName="pooja",Salary=5678},
            new Employee{EmployeeId=4,EmployeeName="kimaya",Salary=7632}

        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(l);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id){
            var e=l.FirstOrDefault(i=>i.EmployeeId==id);
            if(e!=null) return Ok(e);
            else return NotFound();
        }


        [HttpPost]
        public IActionResult Post(Employee e){
            if(e!=null){
                l.Add(e);
                return Ok();
            }
            return NotFound();
            
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id){
            var e=l.FirstOrDefault(i=>i.EmployeeId==id);
            if(e!=null){
               l.Remove(e); 
               return Ok();
            } 
            else return NotFound();

        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id,Employee emp){
            var e=l.FirstOrDefault(i=>i.EmployeeId==id);
            if(e!=null){
                e.EmployeeId=emp.EmployeeId;
                e.EmployeeName=emp.EmployeeName;
                e.Salary=emp.Salary;
                return Ok();
            }
            else return NotFound();
            


        }
    }
}