namespace DisconnectedAdo;
using System.Data.SqlClient;
using System.Data;

class EmployeeDetails{

    string conStr="server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
    SqlConnection con;
    SqlDataAdapter da;
    DataSet ds;
    string str;
    SqlCommandBuilder build;

    public EmployeeDetails(){
        con=new SqlConnection(conStr);
        // con.Open();
        str="select * from employees";
        da=new SqlDataAdapter(str,con); 
        ds=new DataSet(); //dataset has one or more data table, data table has rows and column
        // da.Fill(ds); // fill put one data table in dataset with index 0, another fill put another table in dataset with index 1
        build=new SqlCommandBuilder(da); //haven't wrote sql statement for insert, commanbuilder generate sql insert and other sql statement
        da.MissingSchemaAction=MissingSchemaAction.AddWithKey; //add primary key into the dataset table
        da.Fill(ds,"dtEmployees"); // table can be access using index or name like dtEmployees
    }

    public void GetAllEmployees(){
        foreach(DataRow row in ds.Tables[0].Rows){
            Console.WriteLine(row[0]+" "+row[1]+" "+row["salary"]+" "+row["joindate"]);
        }
    }

    public void AddEmp(Employees e){
        DataRow row=ds.Tables[0].NewRow();
        row[1]=e.Name;
        row["salary"]=e.Salary;
        row[3]=e.JoinDate;
        ds.Tables[0].Rows.Add(row);
        // da.Update(ds.Tables[0]);
        Console.WriteLine("Row inserted");
    }

    public void SearchEmp(int eid){
        DataRow? row=ds.Tables[0].Rows.Find(eid);
        if(row!=null){
            Console.WriteLine(row["employeeid"]+" "+row["employeename"]+" "+row[2]+" "+row[3]);
        }
        else Console.WriteLine("Not found");
    }

    public void DeleteEmp(int eid){
        DataRow? row=ds.Tables[0].Rows.Find(eid);
        if(row!=null){
            row.Delete();
            // da.Update(ds.Tables[0]);
            Console.WriteLine("Row deleted");
        }
        else Console.WriteLine("Not found");
    }

    public void UpdateEmp(int eid,Employees e){
        DataRow? row=ds.Tables[0].Rows.Find(eid);
        if(row!=null){
            row[1]=e.Name;
            row["salary"]=e.Salary;
            row[3]=e.JoinDate;
            // da.Update(ds.Tables[0]);
            Console.WriteLine("Row updated");
        }
        else Console.WriteLine("Not found");
    }

    public void DisplayStates(){
        foreach(DataRow row in ds.Tables[0].Rows){
            Console.WriteLine(row[0]+" "+row.RowState);
        }
        da.Update(ds.Tables[0]);
    }

}