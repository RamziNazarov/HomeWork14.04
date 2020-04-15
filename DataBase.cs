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
            if(connect.State == ConnectionState.Closed)
            connect.Open();
        }
        public void CloseConnecting()
        {
            connect.Close();
        }
        public void Insert (string LastName,string FirstName, string MiddleName, int y,int m,int d)
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
                    int c =0;
                    while(reader.Read())
                    {
                        System.Console.WriteLine($"Id: {reader.GetValue(0)} | LastName: {reader.GetValue(1)} | FirstName: {reader.GetValue(2)} | MiddleName: {reader.GetValue(3)} | BirthDate: {reader.GetValue(4).ToString().Substring(0,10)}");
                        c += (reader.GetValue(0).ToString() == Id.ToString())?1:0;
                    }   
                    if(c == 0)
                        System.Console.WriteLine("Такого Id не существует в базе данных!");
                }
            }
        }
        public void UpdateById(int Id,string LastName,string FirstName,string MiddleName,string BirthDate)
        {
            int y = int.Parse(BirthDate.Substring(0,4)),m = int.Parse(BirthDate.Substring(5,2)),d = int.Parse(BirthDate.Substring(8,2));
            using(SqlCommand command = new SqlCommand("UPDATE Person set LastName = '"+ LastName +"',FirstName ='"+ FirstName+"',MiddleName ='"+ MiddleName +"',BirthDate = DATETIMEFROMPARTS("+y+","+m+","+d+","+1+","+1+","+1+","+1+") where Id =" + Id,connect))
            {
                if(command.ExecuteNonQuery() > 0)
                System.Console.WriteLine("Updated Person with " + Id + " Id!");
                else
                System.Console.WriteLine("Такого Id не существует в базе данных!");
            }    
        }
        public void Delete(int Id)
        {
            using(SqlCommand command = new SqlCommand("delete Person where Id =" + Id,connect))
            {
                if(command.ExecuteNonQuery() > 0)
                System.Console.WriteLine("Успешно удалено!");
                else
                System.Console.WriteLine("Такого Id не существует в базе данных!");
            }
        }
    }
}