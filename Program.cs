using System;

namespace HomeWork14._04
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseWorking dbwork = new DataBaseWorking();
            dbwork.OpenConnecting();
            dbwork.AddPerson("Nazarov","Ramz","Saidovich",DateTime.Now);
            dbwork.CloseConnecting();
            Console.ReadKey();
        }
    }
}
