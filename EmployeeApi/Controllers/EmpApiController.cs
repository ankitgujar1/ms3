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
    }
}