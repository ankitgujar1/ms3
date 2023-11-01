using System;
using System.Data.SqlClient;
using System.Data;

namespace AdoNetApp{

    class DBConnect{
        public static string ConnectionString{
            get{
                return "server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
            }
        }
    }

    class Employees{
        public string? Name{
            get;
            set;
        }

        public int Salary{
            get;
            set;
        }

        public DateTime JoinDate{
            get;
            set;
        }
    }

    class EmpDetails{
        SqlConnection? con;
        public void AddEmp(Employees emp){
            // string conStr="server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
            using SqlConnection con=new SqlConnection(DBConnect.ConnectionString);
            con.Open();
            // string str="insert into Employees values('Ankit Gujar',10000,'12-dec-2020')";

            string str=$"insert into Employees values('{emp.Name}',{emp.Salary},'{emp.JoinDate}')";

            SqlCommand cmd=new SqlCommand(str,con);
            cmd.ExecuteNonQuery();
            
            Console.WriteLine("Row Inserted");
        }

        public void AddEmpUsingProcedure(Employees emp){
            // string conStr="server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
            using(con=new SqlConnection(DBConnect.ConnectionString)){
            con.Open();
            // string str="insert into Employees values('Ankit Gujar',10000,'12-dec-2020')";

            // string str=$"insert into Employees values('{emp.Name}',{emp.Salary},'{emp.JoinDate}')";

            SqlCommand cmd=new SqlCommand("proc_InsertEmp",con);
            cmd.CommandType=CommandType.StoredProcedure;

            //for out parameter
            SqlParameter p_employeeid=new SqlParameter("@employeeid",SqlDbType.Int);
            p_employeeid.Direction=ParameterDirection.Output;
            cmd.Parameters.Add(p_employeeid);

            //for in parameters
            cmd.Parameters.AddWithValue("@employeename",emp.Name);
            cmd.Parameters.AddWithValue("@salary",emp.Salary);
            cmd.Parameters.AddWithValue("@joindate",emp.JoinDate);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Row Inserted {0} using Stored Procedure" ,p_employeeid.Value);
            }
        }


        public void DeleteEmp(int empId){
            // string conStr="server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
            using(con=new SqlConnection(DBConnect.ConnectionString)){
            con.Open();
            // string str="insert into Employees values('Ankit Gujar',10000,'12-dec-2020')";

            string str=$"delete from Employees where EmployeeId={empId}";

            SqlCommand cmd=new SqlCommand(str,con);
            cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Row Deleted");
        }

        public void SearchEmp(int empId){
            // string conStr="server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
            using(con=new SqlConnection(DBConnect.ConnectionString)){
            con.Open();

            string str=$"select * from Employees where EmployeeId={empId}";
            SqlCommand cmd=new SqlCommand(str,con);
            SqlDataReader reader=cmd.ExecuteReader();
            if(reader.Read()){
                Console.WriteLine(reader.GetInt32(0));
                Console.WriteLine(reader.GetString(1));
                Console.WriteLine(reader.GetDecimal(2));
                Console.WriteLine(reader.GetDateTime(3));

            }
            else Console.WriteLine("No such employee");
            reader.Close();
            }
            Console.WriteLine("Employee Found");
            // Console.WriteLine(e)
        }

        // public Employees? SearchEmpWithReturnType(int empId){
        //     // string conStr="server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
        //     using(con=new SqlConnection(DBConnect.ConnectionString)){
        //     con.Open();

        //     string str=$"select * from Employees where EmployeeId={empId}";
        //     SqlCommand cmd=new SqlCommand(str,con);
        //     SqlDataReader reader=cmd.ExecuteReader();
        //     if(reader.Read()){
        //         Employees e=new Employees();
        //         // e.I = reader.GetInt32(0);
        //         e.Name = reader.GetString(1);
        //         e.Salary = Convert.ToDouble(reader.GetDecimal(2));
        //         e.JoinDate = reader.GetDateTime(3);

        //     }
        //     else Console.WriteLine("No such employee");
        //     reader.Close();
        //     }
        //     Console.WriteLine("Employee Found");
        //     // Console.WriteLine(e)
        // }

        public void UpdateEmp(int empId, Employees emp){
            // string conStr="server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
            using(con=new SqlConnection(DBConnect.ConnectionString)){
            con.Open();

            string str=$"update Employees set EmployeeName='{emp.Name}',Salary={emp.Salary},JoinDate='{emp.JoinDate}' where EmployeeId={empId}";
            SqlCommand cmd=new SqlCommand(str,con);
            cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Row Updated");

        }

        public void GetAllEmployee(){
            // string conStr="server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
            using(con=new SqlConnection(DBConnect.ConnectionString)){
            con.Open();

            string str=$"select * from Employees";
            SqlCommand cmd=new SqlCommand(str,con);
            // cmd.ExecuteNonQuery();
            SqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read()){
                Console.WriteLine("{0},{1},{2},{3}",reader.GetInt32(0),reader.GetString(1),reader.GetDecimal(2),reader.GetDateTime(3));
            }
            reader.Close();
            }
            // Console.WriteLine("Row Updated");
        }

       public void DataReaderMethods()

        {

            // string conStr = "server=localhost;database=ltiDB;uid=sa;password=examlyMssql@123";
            using(con = new SqlConnection(DBConnect.ConnectionString)){
            con.Open();
            string str = $"select * from employees";
            SqlCommand cmd = new SqlCommand(str,con);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Console.WriteLine("Table has Rows: "+reader.HasRows);
            Console.WriteLine("Fields in the table: "+reader.FieldCount);
            Console.WriteLine("Column 1 name: "+reader.GetName(1));
            Console.WriteLine("Index no of Ename: "+reader.GetOrdinal("employeename"));
            Console.WriteLine("Ename is null: "+reader.IsDBNull(1));
            Console.WriteLine("Ename is: "+reader.GetSqlValue(1));
            Console.WriteLine("Salary is: "+reader["Salary"]);

            reader.Close();
            }

        }

        public void GetMaxSalary(){
            try{
                using SqlConnection con=new SqlConnection(DBConnect.ConnectionString);
                con.Open();
                SqlCommand cmd=new SqlCommand("select max(salary) from employees",con);
                object o=cmd.ExecuteScalar();
                if(!Convert.IsDBNull(o)) Console.WriteLine("Max Salary: "+o);
                else Console.WriteLine("Not found");
            }
            catch(Exception e){ Console.WriteLine(e.Message);}
        }

        public void GetXMLData(){
            try{
                using SqlConnection con=new SqlConnection(DBConnect.ConnectionString);
                con.Open();
                string str="select * from employees for xml auto";
                SqlCommand cmd=new SqlCommand(str,con);
                System.Xml.XmlReader reader=cmd.ExecuteXmlReader();
                reader.Read();
                while(!reader.EOF) Console.WriteLine(reader.ReadOuterXml());
                reader.Close();
            }
            catch(Exception e){
                Console.WriteLine(e.ToString());
            }
        }
    }

    class Program{
        public static void Main(string[] args)
        {
            // string conStr="server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
            // SqlConnection con=new SqlConnection(conStr);
            // con.Open();
            // string str="insert into Employees values('Ankit Gujar',10000,'12-dec-2020')";
            // SqlCommand cmd=new SqlCommand(str,con);
            // cmd.ExecuteNonQuery();
            // con.Close();
            // con.Dispose();
            // Console.WriteLine("Row Inserted");

            EmpDetails ed=new EmpDetails();
            
            Employees e=new Employees{
                Name="Ethan",
                Salary=10000,
                JoinDate=DateTime.Parse("12-dec-2022")
            };

            // ed.AddEmp(e);

            // ed.DeleteEmp(2);

            // ed.SearchEmp(1);

            // ed.UpdateEmp(6,e);

            // ed.GetAllEmployee();

            // ed.DataReaderMethods();

            // ed.AddEmpUsingProcedure(e);

            // ed.GetMaxSalary();

            ed.GetXMLData();

        }
    }
}
