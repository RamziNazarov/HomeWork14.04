using System;
using System.Data;
using System.Data.SqlClient;

namespace HomeWork14._04
{
    class DataBaseWorking
    {
        SqlConnection connect = new SqlConnection("Data source=localhost; Initial catalog=HomeWork14.04; Integrated security=true");
        public void OpenConnecting ()
        {
            connect.Open();
            if(connect.State == ConnectionState.Open)
            System.Console.WriteLine("Connected");
        }
        public void CloseConnecting()
        {
            connect.Close();
        }
        public void AddPerson (string LastName,string FirstName, string MiddleName, int y,int m,int d)
        {
            using(SqlCommand command = new SqlCommand("insert into Person([LastName],[FirstName],[MiddleName],[BirthDate]) values ('"+ LastName +"','" + FirstName + "','" + MiddleName + "',DATETIMEFROMPARTS("+y+","+m+","+d+","+1+","+1+","+1+","+1+"))",connect))
            {
                int a = command.ExecuteNonQuery();
                if(a > 0)
                System.Console.WriteLine("Successfully added to database!");
            }
        }
    }
}