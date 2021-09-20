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
            Console.Write("SRollno\tSName\tSContact\tSAddress\tSEmail\tSTrainer\tSbatchno\tSmarks1\tSmarks2\n");
            while (dr.Read())
            {
                Console.Write("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}\n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
            }
            con.Close();

        }

        //    DispalyTrainer(){
    }


    // DisplayBatch(){
}
        public static void insertRecords(int rollno, string name, string contact, string address, string email, string trainer, string batch,int marks1,int marks2)
        {
            con.Open();
            string query = "insert into student values(" + rollno + ",'" + name + "','" + contact + "','" + address + "','" + email + "','" + trainer + "','" + batch + "'," + marks1 + "," + marks2 + ")";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            //try
            //{
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //}
            //catch (System.Data.SqlClient.SqlException ex)
            //{
            //    string msg = "Insert Error:";
            //    msg += ex.Message;
            //}
            //finally
            //{
            //    con.Close();
            //}

        }
    }
}
