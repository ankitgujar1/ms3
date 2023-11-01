using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreCodeFirst.Data;

    public class Department
    {
        public int DepartmentId{get;set;}
        public string? DepartmentName{set;get;}

        public virtual ICollection<Employee>? Employees {get;set;}
    }
