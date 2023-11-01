using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EfCoreCodeFirst.Data
{
    public class DotNet2DbContext:DbContext{

        protected override void OnConfiguring(DbContextOptionsBuilder options){
             options.UseSqlServer("User ID=sa;password=examlyMssql@123;MultipleActiveResultSets=true;server=localhost;Database=DotNet2Db;trusted_connection=false;Persist Security Info=False;Encrypt=False");
        }
        public virtual DbSet<Department> Departments{set;get;}
        public virtual DbSet<Employee> Employees{set;get;}
    }
}