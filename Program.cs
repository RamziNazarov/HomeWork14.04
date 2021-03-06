﻿using System;

namespace HomeWork14._04
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseWorking dbwork = new DataBaseWorking();
            dbwork.OpenConnecting();
            int k = 0;
            while(k != 6)
            {
                System.Console.Write("1. Insert\n2. Select All\n3. Select by Id\n4. Update\n5. Delete\n6. Exit\nВаш выбор: ");
                k = int.Parse(Console.ReadLine());
                switch(k)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Введите фамилию: "); 
                        string lastName = Console.ReadLine();
                        Console.Write("Введите имя: "); 
                        string firstName = Console.ReadLine();
                        Console.Write("Введите отчество: "); 
                        string middleName = Console.ReadLine();
                        Console.Write("Введите дату рождения (гггг-мм-дд): ");
                        string date = Console.ReadLine();
                        int y = int.Parse(date.Substring(0,4)),m = int.Parse(date.Substring(5,2)),d = int.Parse(date.Substring(8,2));  
                        dbwork.Insert(lastName,firstName,middleName,y,m,d);
                        System.Console.WriteLine("-------------------------------------------------------------------------------------");
                    break;
                    case 2:
                        Console.Clear();
                        dbwork.SelectAll();
                        System.Console.WriteLine("-------------------------------------------------------------------------------------");
                    break;
                    case 3:
                        Console.Clear();
                        System.Console.Write("Введите Id: ");
                        int Id = int.Parse(Console.ReadLine());
                        dbwork.SelectById(Id);
                        System.Console.WriteLine("-------------------------------------------------------------------------------------");
                    break;
                    case 4:
                        Console.Clear();
                        System.Console.Write("Введите Id: ");
                        int idtoupdate = int.Parse(Console.ReadLine());
                        System.Console.Write("Введите новую фамилия: ");
                        string lastNameforupdate = Console.ReadLine();
                        System.Console.Write("Введите новое имя: ");
                        string firstNameforupdate = Console.ReadLine();
                        System.Console.Write("Введите новое отчество: ");
                        string middleNameforupdate = Console.ReadLine();
                        System.Console.Write("Введите дату рождения (гггг-мм-дд): ");
                        string birthDate = Console.ReadLine();
                        dbwork.UpdateById(idtoupdate,lastNameforupdate,firstNameforupdate,middleNameforupdate,birthDate);
                        System.Console.WriteLine("-------------------------------------------------------------------------------------");
                    break;
                    case 5:
                        Console.Clear();
                        System.Console.Write("Введите Id: ");
                        int id = int.Parse(Console.ReadLine());
                        dbwork.Delete(id);
                        System.Console.WriteLine("-------------------------------------------------------------------------------------");
                    break;
                    default:
                        Console.Clear();
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
