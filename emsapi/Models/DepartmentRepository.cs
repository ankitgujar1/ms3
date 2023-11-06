using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emsapi.Models;
 
namespace EmpApi.Models
{
    public class DepartmentRepository : IDepartment
    {
 
        MyDatabaseContext context = new MyDatabaseContext();
 
        public void AddDept(Department dept)
        {
            context.Departments.Add(dept);
            context.SaveChanges();
        }
 
        public void DeleteDept(int id)
        {
            Department d = context.Departments.Find(id);
            context.Departments.Remove(d);
            context.SaveChanges();
        }
 
        public void EditDept(Department Dept)
        {
            Department d = context.Departments.Find(Dept.DepartmentId);
            d.DepartmentName = Dept.DepartmentName;
            context.SaveChanges();
 
        }
 
        public Department FindDept(int id)
        {
            var data = context.Departments.Find(id);
            return  data;
        }
 
        public List<Department> GetDepartments()
        {
            return context.Departments.ToList();
        }
 
    }
}