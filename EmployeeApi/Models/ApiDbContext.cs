using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Models
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options){

        }

        public virtual DbSet<Employee> Employees{get;set;}

        public virtual DbSet<Department> Departments{get;set;}
    }
}