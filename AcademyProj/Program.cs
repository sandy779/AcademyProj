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
            Console.BackgroundColor = ConsoleColor.Gray;
            int ch;
            char reply = 'y';
            Class1.CreateConnection();
            
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("******************************************WELCOME TO TQ ACADEMY***********************************************");
            Console.WriteLine();
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
           Console.WriteLine("===================================SELECT OPERATION==================================================");
         Console.WriteLine("\t\t1.Student Operations");
            Console.WriteLine("\t\t2.Performance Reports");
            ch = Convert.ToInt32(Console.ReadLine());
            

            
;            switch (ch)
            {
                case 1:

                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("=============================MAIN MENU===============================");
                        Console.WriteLine();
                        Console.WriteLine("1.ADDING RECORDS");
                        Console.WriteLine("2.UPDATE STUDENT CONTACT");
                        Console.WriteLine("3.DELETING RECORDS");
                        Console.WriteLine("4.DISPLAYING RECORDS");
                        Console.WriteLine("5.VIEW TRAINER NAME");
                        Console.WriteLine("6.VIEW BATCH");
                        Console.WriteLine("7.UPDATE MARKS OF STUDENT");
                        Console.WriteLine("8.EXITING APPLICATION");
                        Console.WriteLine("======================================================================");
                        Console.WriteLine("ENTER YOUR CHOICE:");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        int rollno;
                        string batchid;
                        string name;
                        string contact;
                        string address;
                        int mark;
                        string trainerid;

                        

                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Enter Your details Rollno, Name, contact, address, email, trainerid, batchID, marks1, and marks2");
                                rollno = Convert.ToInt32(Console.ReadLine());
                                name = Console.ReadLine();
                                contact = Console.ReadLine();
                                address = Console.ReadLine();
                                
                                trainerid = Console.ReadLine();
                                batchid = Console.ReadLine();
                                

                                // display trainer and batch details 

                                //Class1.DisplayTrainer();
                                //Class1.DisplayBatch();

                                Class1.insertRecords(rollno, name, contact, address, trainerid, batchid);
                                break;
                            case 2:
                                Console.WriteLine("Enter RollNo Of student");
                                rollno = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter New Contact");
                                contact = Console.ReadLine();
                                Class1.updateContact(contact, rollno);
                                break;
                            case 3:
                                Console.WriteLine("Enter RollNo");
                                rollno = Convert.ToInt32(Console.ReadLine());
                                Class1.deleterecord(rollno);
                                break;
                            case 4:
                                Console.WriteLine("=======================================Displaying the Records===============================");
                                Class1.Display();
                                break;
                            case 5:
                                Console.WriteLine("Enter TrainerId");
                                trainerid = Console.ReadLine();
                                Class1.DisplayTrainer(trainerid);
                                break;
                            case 6:
                                Console.WriteLine("Enter BatchId");
                                batchid = Console.ReadLine();
                                Class1.DisplayBatch(batchid);
                                break;
                            case 7:
                                Console.WriteLine("Enter RollNo");
                                rollno = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Marks");
                                mark = Convert.ToInt32(Console.ReadLine());
                                Class1.updatemarks(mark,rollno);
                                break;
                            case 8:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }



                        Console.WriteLine("Do you wish to continue");
                        reply = Convert.ToChar(Console.ReadLine());
                    } while (reply == 'y');
                    break;

                case 2:

                    Console.WriteLine("========================= Reports=======================");
                    Console.WriteLine("1. Top 5 Merit List for Specific Batch");
                    Console.WriteLine("2.Top 10 Merit List For All Batches");
                    Console.WriteLine("3.Top BatchName & TrainerName");
                    Console.WriteLine("4.Low Performance Batch");
                    Console.WriteLine("5.EXIT");
                    Console.WriteLine("0.Return to Main Menu");
                    Console.WriteLine("ENTER CHOICE:");
                    int c = Convert.ToInt32(Console.ReadLine());
                    string batchid1;
                    switch (c)
                    {
                        case 1:
                            Console.WriteLine("Enter BatchId");
                            batchid1 = Console.ReadLine();
                            Class1.topfive(batchid1);
                            break;
                        case 2:
                            Class1.topten();
                            break;
                         case 3:
                            Class1.Top();
                            break;
                        case 4:
                            Class1.lowscore();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        case 0:
                            return;
                           
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }

                    break;
            }
            Console.ReadLine();


        }
    }
}
