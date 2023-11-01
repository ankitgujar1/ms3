using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace U.Models
{
    public class EDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder o){
            o.UseSqlServer("User ID=sa;password=examlyMssql@123;MultipleActiveResultSets=true;server=localhost;Database=EDB;trusted_connection=false;Persist Security Info=False;Encrypt=False");
        }

        public virtual DbSet<Employee> Employees{get;set;}
    }
}