using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace mvcefwithdb.Data
{
    public class CodeFirstDbContext:DbContext
    {
        // protected override void OnConfiguring(DbContextOptionsBuilder options){
        //     string conStr="User ID=sa;password=examlyMssql@123;MultipleActiveResultSets=true;server=localhost;Database=CodeFirstDb;trusted_connection=false;Persist Security Info=False;Encrypt=False";
        //     options.UseSqlServer(conStr);
        // }

        public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options):base(options){
            
        }

       

        public DbSet<Employee>? Employees{get; set;}

        public DbSet<Department>? Departments{get; set;}
        
    }
}