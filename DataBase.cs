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
        public void AddPerson (string LastName,string FirstName, string MiddleName, DateTime BirthDate)
        {
            string commandText = $"insert into Person ([LastName],[FirstName],[MiddleName],[BirthDate]) values ('LastName','FirstName','MiddleName',1998.07.25)";
            using(SqlCommand command = new SqlCommand(commandText,connect)){
                
                System.Console.WriteLine("Successfull");
            }
        }
    }
}