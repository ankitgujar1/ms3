using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmpApi.Models
{
    public class EmpApiDbContext:DbContext
    {
        public EmpApiDbContext(DbContextOptions<EmpApiDbContext> options):base(options){

        }

        public virtual DbSet<Employee> Employees{get;set;}

        public virtual DbSet<Department> Departments{get;set;}
    }
}