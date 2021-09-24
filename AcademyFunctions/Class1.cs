using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AcademyFunctions
{
    public class Class1
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlCommand cmd1;
        static SqlDataReader dr;


        public static void CreateConnection()
        {
            try
            {
                string constr = "Data Source=DESKTOP-2UMN69M;Initial Catalog=Academydb; User ID=sa;Password=pass@123";
                con = new SqlConnection();

                con.ConnectionString = constr;
                // con.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Please check connection details");
            }

         
        }

        public static void Display()
        {
            con.Open();
            string query = "Select * from student";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
            Console.Write("Rollno\tName\tContact\t\tAddress\t\t\tTrainerid\t\t\tBatchId\n");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
            while (dr.Read())
            {
                Console.Write("{0}\t{1}\t{2}\t\t{3}\t\t\t{4}\t\t{5}\n", dr[0], dr[1], dr[2], dr[3], dr[4],dr[5]);

            }
            Console.WriteLine("==============================================================================================================");
            con.Close();

        }

        public static void DisplayTrainer(string trainerid)
        {
            con.Open();
            string query = "Select TrainerName from Trainer where TrainerId="+trainerid+"";
            cmd = new SqlCommand(query, con);
            dr=   cmd.ExecuteReader();
            Console.WriteLine("TrainerName");
            while (dr.Read())
            {
                Console.WriteLine("{0}", dr[0]);
            }
            con.Close();
        }
        public static void DisplayBatch(string batchid)
        {
            con.Open();
            string query = "select BatchName from Batch b join student stud on b.BatchId = stud.BatchId where stud.BatchId = '" + batchid + "'";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("TrainerName");
            while (dr.Read())
            {
                Console.WriteLine("{0}", dr[0]);
            }
            con.Close();
        }


        // DisplayBatch()

public static void insertRecords(int rollno, string name, string contact, string address,  string trainer, string batch)
{
    con.Open();
    string query = "insert into student values(" + rollno + ",'" + name + "','" + contact + "','" + address + "','" + trainer + "','" + batch + "')";
    string query2="insert into Exam values("+rollno+",null)";
    cmd = new SqlCommand(query, con);
    cmd1 = new SqlCommand(query2, con);
    cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();


            /* try
             {

                cmd.ExecuteNonQuery();
             }
             catch (System.Data.SqlClient.SqlException ex)
             {
                 string msg = "Insert Error:";
                 msg += ex.Message;
             }
             finally
             {
                 con.Close();
             }*/
            con.Close();

        }
        public static void deleterecord(int rollno)
        {
            con.Open();
            string query = "delete from student where SRollno="+rollno+"";
            cmd=new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void updateContact(string contact,int rollno)
        {
            con.Open();
            string query = "update student set SContact=" + contact + "where SRollno="+rollno+"";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void updatemarks(int marks,int rollno)
        {
            con.Open();
            string query = "update Exam set Marks=@marks where SRollno=@r";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("marks", marks));
            cmd.Parameters.Add(new SqlParameter("r", rollno));
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void topfive(string batchid1)
        {
            con.Open();
            //string query = "select * from vwtop5";
            cmd = new SqlCommand("prctoo5", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("batchid", batchid1));
           dr= cmd.ExecuteReader();
            Console.WriteLine("====================================TOP 5 MERIT LIST IN SPECIFIC BATCH=====================================================");
            Console.Write("STUDENT NAME\t\tMARKS OBTAINED\n");
            while (dr.Read())
            {
                Console.WriteLine("{0}\t\t\t\t{1}\t\t{2}\n", dr[0],dr[1],dr[2]);
            }
            con.Close();
        }
        public static void topten()
        {
            con.Open();
            string query = "select top 10 SName,Marks,BatchId from student stud join Exam ex on stud.Srollno=ex.SRollno order by Marks desc";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("====================================TOP 10 MERIT LIST IN ALL BATCHES=====================================================");
            Console.Write("STUDENT NAME\t\tMARKS OBTAINED\t\t\t\tBATCHID\n");
            while (dr.Read())
            {
                Console.WriteLine("{0}\t\t\t\t{1}\t\t\t\t{2}\n", dr[0], dr[1],dr[2]);
            }
            con.Close();
        }

        public static void Top()
        {
            con.Open();
            string query = "select* from view1";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("====================================TOP TRAINER AND TOP BATCH =====================================================");
            Console.Write("TOP TRAINER ID\t\tTOP BATCH ID\n");
            while (dr.Read())
            {
                Console.WriteLine("{0}\t\t\t\t{1}\n", dr[0], dr[1]);
            }
            con.Close();
        }
        public static void lowscore()
        {
            con.Open();
            string query = "select top 1 BatchId from  student stud join Exam ex on stud.SRollno=ex.SRollno group by stud.BatchId having avg(Marks)<70";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("====================================LOW SCORE BATCH=====================================================");
            Console.Write("LOW PERFORMANCE BATCH \n");
            while (dr.Read())
            {
                Console.WriteLine("{0}\n", dr[0]);
            }
            con.Close();
        }
    }
}

