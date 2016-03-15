using SqlHelperLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            String conString=@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Dac\Project\FinalProject_Mulicuisine_Food_Ordering_System\TestConsoleApplication\TestDb.mdf;Integrated Security=True";
            SqlHelper helper = new SqlHelper(conString);
            SqlConnection con = new SqlConnection();        
            string cmdStr = "SELECT * FROM Table";
            //Create Command Object
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdStr;
            //associate command with connection
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int cutomerId = int.Parse(dr["id"].ToString());
                    string firstName = dr["firstname"].ToString();
                    string lastName = dr["lastname"].ToString();
                    string email = dr["email"].ToString();
                    string phone = dr["phoneno"].ToString();
                    DateTime bDate = Convert.ToDateTime(dr["birthdate"]);
                    string address = dr["address"].ToString();
                    Console.WriteLine(firstName + " " + lastName + "  " + email + "  " + phone + "  " + address + " " + bDate.ToShortDateString());
                }

            }
            catch (OleDbException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

            Console.ReadLine();
        }
    }
}
