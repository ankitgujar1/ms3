using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Models
{
    public class Designation
    {
        public int DesignationId{get;set;}
        public string? DesignationName{get;set;}
        public virtual ICollection<Employee>? Employees{get;set;}
    }
}