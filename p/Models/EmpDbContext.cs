using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace p.Models
{
    public class EmpDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseSqlServer("User ID=sa;password=examlyMssql@123;MultipleActiveResultSets=true;server=localhost;Database=EmpDb;trusted_connection=false;Persist Security Info=False;Encrypt=False");
        }

        public virtual DbSet<Employee> Employees{get;set;}
    }
}