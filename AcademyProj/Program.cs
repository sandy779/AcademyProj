using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AcademyFunctions;
namespace AcademyProj
{
    class Program
    {
        static void Main(string[] args)
        {
            char reply = 'y';
            Class1.CreateConnection();
            Console.WriteLine("Connection with database Successful..");
            Console.ReadLine();
            do
            { 
            Console.WriteLine("=============================MAIN MENU===============================");
            Console.WriteLine("1.ADDING RECORDS");
            Console.WriteLine("2.UPDATING RECORDS");
            Console.WriteLine("3.DELETING RECORDS");
            Console.WriteLine("4.DISPLAYING RECORDS");
            Console.WriteLine("5.EXITING APPLICATION");

            Console.WriteLine("ENTER YOUR CHOICE:");
            int choice = Convert.ToInt32(Console.ReadLine());
                int rollno;
                string name;
                string contact;
                string address;
                string email;
                string trainer;
                string batch;
                int marks1, marks2;
            switch (choice)
            {
                case 1:
                        Console.WriteLine("Enter Your details Rollno, Name, contact, address, email, trainerid, batch, marks1, and marks2");
                        rollno = Convert.ToInt32(Console.ReadLine());
                        name = Console.ReadLine();
                        // display trainer and batch details 

                        //Class1.DisplayTrainer();
                        //Class1.DisplayBatch();

                        Class1.insertRecords(rollno, name,contact, address, email, trainerid, batch, marks1, marks2);
                        break;
                case 2: break;
                case 3: break;
                case 4:
                    Console.WriteLine("Displaying the Records");
                    Class1.Display();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            Console.WriteLine("Do you wish to continue");
            reply = Convert.ToChar(Console.ReadLine());
        }while(reply=='y');
            Console.ReadLine();
        }
    }
}
