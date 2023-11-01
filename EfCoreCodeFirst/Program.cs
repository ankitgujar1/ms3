using EfCoreCodeFirst.Data;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {

        DotNet2DbContext db = new DotNet2DbContext();

        // Employee e = new Employee
        // {
        //     EmployeeName = "pooja",
        //     DepartmentId = 2,
        //     Salary = 1010,
        //     JoinDate = DateTime.Parse("30-nov-2020")
        // };

        // db.Employees.Add(e);
        // db.SaveChanges();
        // Console.WriteLine($"Row added with id " + e.EmployeeId);


        // var i1 = db.Employees.Find(5);
        // if (i1 != null) Console.WriteLine(i1.EmployeeId + ", " + i1.EmployeeName + ", " + i1.DepartmentId + ", " + i1.Salary);
        // else Console.WriteLine($"Not found");

        // var i = db.Employees.Find(4);
        // if (i != null)
        // {
        //     db.Employees.Remove(i);
        //     db.SaveChanges();
        //     Console.WriteLine($"Deleted");

        // }
        // else Console.WriteLine($"Not found");

        // var i = db.Employees.Find(1);
        // if (i != null)
        // {
        //     i.EmployeeName = "jj";
        //     i.DepartmentId = 1;
        //     db.SaveChanges();
        //     Console.WriteLine($"Updated");
        // }
        // else Console.WriteLine($"Not found");


        // foreach (var i in db.Employees.Include("Department"))
        // {
        //     Console.WriteLine(i.EmployeeId + ", " + i.EmployeeName + ", " + i.Department.DepartmentName + ", " + i.Salary); //normally we have to join for this

        // }


        EmployeeDb e=new EmployeeDb();
        while (true)
        {
            Console.WriteLine($"1. Add");
            Console.WriteLine($"2. Display");
            Console.WriteLine($"3. Find");
            Console.WriteLine($"4. Update");
            Console.WriteLine($"5. Delete");
            Console.WriteLine($"6. Exit");

            int n = Convert.ToInt32(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine($"Enter name");
                string? name = Console.ReadLine();

                Console.WriteLine($"Enter dept id");
                int did = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine($"Enter salary");
                double salary = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"Enter joining date");
                string? date = Console.ReadLine();
                Employee emp = new Employee
                {
                    EmployeeName = name,
                    DepartmentId = did,
                    Salary = salary,
                    JoinDate = DateTime.Parse(date)
                };

                e.AddEmp(emp);
            }
            else if (n == 2)
            {
                e.DisplayEmp();
            }

            else if (n == 3)
            {
                Console.WriteLine($"Enter id");
                int id = Convert.ToInt32(Console.ReadLine());
                e.FindEmp(id);
            }

            else if (n == 4)
            {
                Console.WriteLine($"Enter id");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Enter new name");
                string? name = Console.ReadLine();

                Console.WriteLine($"Enter new dept id");
                int did = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine($"Enter new salary");
                double salary = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"Enter new joining date");
                string? date = Console.ReadLine();
                Employee emp = new Employee
                {
                    EmployeeName = name,
                    DepartmentId = did,
                    Salary = salary,
                    JoinDate = DateTime.Parse(date)
                };
                e.UpdateEmp(id, emp);
            }

            else if (n == 5)
            {
                Console.WriteLine($"Enter id");
                int id = Convert.ToInt32(Console.ReadLine());
                e.DeleteEmp(id);
            }
            else break;
        }

    }
}
