using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreCodeFirst.Data;

    public class EmployeeDb
    {
        DotNet2DbContext db=new DotNet2DbContext();

        public void AddEmp(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
        }

        public void FindEmp(int id)
        {
            Employee? i = db.Employees.Find(id);
            if (i != null)
            {
                Console.WriteLine(i.EmployeeId + ", " + i.EmployeeName + ", " + i.DepartmentId + ", " + i.Salary);
            }
            else Console.WriteLine($"Not found");

        }

        public void DeleteEmp(int id)
        {
            Employee? i = db.Employees.Find(id);
            if (i != null)
            {
                db.Employees.Remove(i);
                db.SaveChanges();
            }
            else Console.WriteLine($"Not found");
        }

        public void DisplayEmp()
        {

            foreach (var i in db.Employees)
            {
                Console.WriteLine(i.EmployeeId + ", " + i.EmployeeName + ", " + i.DepartmentId + ", " + i.Salary); //normally we have to join for this

            }

        }

        public void UpdateEmp(int id, Employee e)
        {
            var i = db.Employees.Find(id);
            if (i != null)
            {
                i.EmployeeName = e.EmployeeName;
                i.DepartmentId = e.DepartmentId;
                i.Salary=e.Salary;
                db.SaveChanges();
                Console.WriteLine($"Updated");
            }
            else Console.WriteLine($"Not found");
        }
    }
