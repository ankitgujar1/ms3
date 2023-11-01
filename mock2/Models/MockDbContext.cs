using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace mock2.Models
{
    public class MockDbContext:DbContext
    {
        public MockDbContext(DbContextOptions<MockDbContext> options):base(options){

        }

        public virtual DbSet<BloodDonor> BloodDonors{get;set;}
    }

    
}