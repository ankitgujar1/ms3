using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wprac.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;
 
namespace wprac.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext db;
        public EmployeeRepository (ApplicationDbContext db)
        {
            this.db=db;
        }
        public ICollection<Employee> GetAllEmployee()
        {
            var e = db.Employees.ToList();
            return(e);
        }
        public void AddEmployee(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
        }
        public Employee FindById(int id)
        {
            var e = db.Employees.Find(id);
            return (e);
        }
        public void DeleteEmployee(int id)
        {
            var e = db.Employees.Find(id);
            db.Employees.Remove(e);
            db.SaveChanges();
        }
 
        public void EditEmployee (Employee emp)
        {
            db.Update(emp);
            db.SaveChanges();
        }
    }
}