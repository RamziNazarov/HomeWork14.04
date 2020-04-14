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
        public void SelectAll()
        {
            using(SqlCommand command = new SqlCommand("select * from Person",connect))
            {
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        System.Console.WriteLine($"Id: {reader.GetValue(0)} | LastName: {reader.GetValue(1)} | FirstName: {reader.GetValue(2)} | MiddleName: {reader.GetValue(3)} | BirthDate: {reader.GetValue(4).ToString().Substring(0,10)}");
                    }
                }
            }
        }
        public void SelectById(int Id)
        {
            using(SqlCommand command = new SqlCommand("select * from Person where Id =" + Id,connect))
            {
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        System.Console.WriteLine($"Id: {reader.GetValue(0)} | LastName: {reader.GetValue(1)} | FirstName: {reader.GetValue(2)} | MiddleName: {reader.GetValue(3)} | BirthDate: {reader.GetValue(4).ToString().Substring(0,10)}");
                    }
                }
            }
        }
    }
}