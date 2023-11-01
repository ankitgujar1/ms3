using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace v.Data
{
    public class VDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder o){
            o.UseSqlServer("User ID=sa;password=examlyMssql@123;MultipleActiveResultSets=true;server=localhost;Database=VDb;trusted_connection=false;Persist Security Info=False;Encrypt=False");
        }

        public virtual DbSet<Employee> Employees{get;set;}
        public virtual DbSet<Department> Departments{get;set;}
    }
}