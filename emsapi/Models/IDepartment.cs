using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emsapi.Models
{
    public interface IDepartment
    {
        List<Department> GetDepartments();
        Department FindDept(int id);
        void AddDept(Department dept);
        void EditDept(Department dept);
        void DeleteDept(int id);
    }
}