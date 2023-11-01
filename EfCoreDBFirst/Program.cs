using EfCoreDBFirst.Data;
using Microsoft.EntityFrameworkCore;
MyDatabaseContext db = new MyDatabaseContext();

// Employee e=new Employee{
//     EmployeeName="harry",
//     DepartmentId=1,
//     Salary=1010,
//     JoinDate=DateTime.Parse("30-nov-2020")
// };

// db.Employees.Add(e);
// db.SaveChanges();

// Console.WriteLine($"Row added with id "+e.EmployeeId);

// foreach (var i in db.Employees.Include("Department"))
// {
//     Console.WriteLine(i.EmployeeId+", "+i.EmployeeName+", "+i.Department.DepartmentName+", "+i.Salary); //normally we have to join for this

// }

// var i=db.Employees.Find(3);
// if(i!=null) Console.WriteLine(i.EmployeeId+", "+i.EmployeeName+", "+i.DepartmentId+", "+i.Salary);
// else Console.WriteLine($"Not found");

// var i=db.Employees.Find(3);
// if(i!=null){
//     db.Employees.Remove(i);
//     db.SaveChanges();
//     Console.WriteLine($"Deleted");

// }
// else Console.WriteLine($"Not found");

// var i=db.Employees.Find(1);
// if(i!=null){
//     i.EmployeeName="jj";
//     i.DepartmentId=3;
//     db.SaveChanges();
//     Console.WriteLine($"Updated");
// }
// else Console.WriteLine($"Not found");



//short way to crud
//Add

// Employee emp=new Employee{
//     EmployeeName="ksi",
//     DepartmentId=1,
//     Salary=1010,
//     JoinDate=DateTime.Parse("30-nov-2020")
// };

// db.Entry(emp).State=EntityState.Added;

//Delete

var i1=db.Employees.Find(8);
if(i1!=null){
    db.Entry(i1).State=EntityState.Deleted;
}else Console.WriteLine($"not found");

//Find

// var i=db.Employees.Find(6);
// if(i!=null){
//     //print found data
// }else Console.WriteLine($"not found");

//update

// var i1=db.Employees.Find(6);
// if(i1!=null){
//     i1.EmployeeName="pooja";
//     db.Entry(i1).State=EntityState.Modified;
// }else Console.WriteLine("not found");

//Display
db.SaveChanges();

var empList=db.Employees.Include("Department");
foreach(var i in empList){
    Console.WriteLine(i.EmployeeId+", "+i.EmployeeName+", "+i.Department.DepartmentName+", "+db.Entry(i).State);
    
}

// EmpDb e = new EmpDb();
// e.DisplayEmp();






// // e.AddEmp(emp);

// // e.DisplayEmp();

// // e.FindEmp(2);

// // e.UpdateEmp(2,emp);

// // e.DeleteEmp(1);

// while (true)
// {
//     Console.WriteLine($"1. Add");
//     Console.WriteLine($"2. Display");
//     Console.WriteLine($"3. Find");
//     Console.WriteLine($"4. Update");
//     Console.WriteLine($"5. Delete");

//     int n = Convert.ToInt32(Console.ReadLine());

//     if (n == 1)
//     {
//         Console.WriteLine($"Enter name");
//         string? name=Console.ReadLine();

//         Console.WriteLine($"Enter dept id");
//         int did=Convert.ToInt32(Console.ReadLine());
        
        
//         Console.WriteLine($"Enter salary");
//         decimal salary=Convert.ToDecimal(Console.ReadLine());

//         Console.WriteLine($"Enter joining date");
//         string? date=Console.ReadLine();
//         Employee emp = new Employee
//         {
//             EmployeeName = name,
//             DepartmentId = did,
//             Salary = salary,
//             JoinDate = DateTime.Parse(date)
//         };

//         e.AddEmp(emp);
//     }
//     else if(n==2){
//         e.DisplayEmp();
//     }

//     else if(n==3){
//         Console.WriteLine($"Enter id");
//         int id=Convert.ToInt32(Console.ReadLine());
//         e.FindEmp(id);
//     }

//     else if(n==4){
//         Console.WriteLine($"Enter id");
//         int id=Convert.ToInt32(Console.ReadLine());

//         Console.WriteLine($"Enter new name");
//         string? name=Console.ReadLine();

//         Console.WriteLine($"Enter new dept id");
//         int did=Convert.ToInt32(Console.ReadLine());
        
        
//         Console.WriteLine($"Enter new salary");
//         decimal salary=Convert.ToDecimal(Console.ReadLine());

//         Console.WriteLine($"Enter new joining date");
//         string? date=Console.ReadLine();
//         Employee emp = new Employee
//         {
//             EmployeeName = name,
//             DepartmentId = did,
//             Salary = salary,
//             JoinDate = DateTime.Parse(date)
//         };
//         e.UpdateEmp(id,emp);
//     }

//     else if(n==5){
//         Console.WriteLine($"Enter id");
//         int id=Convert.ToInt32(Console.ReadLine());
//         e.DeleteEmp(id);
//     }
// }
