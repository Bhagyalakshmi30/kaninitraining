using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BloodBank
{
    internal class DBlogin
    {
        //Create Static String to Connect Database
        private string connection_string = @"Data source=DESKTOP-A8F8FKV\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=SSPI";
        public bool loginCheck(string?username,string?password)
        {
            //Create a Boolean Variable and SEt its default value to false
            bool isSuccess = false;

            //Connecting DAtabase
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                //SQL Query to Check Login BAsed on Usename and Password
                string sql = "SELECT * FROM users WHERE username=@username AND password=@password";

                //Create SQL Command to Pass the value to SQL Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pass the value to SQL Query Using Parameters
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                //SQl Data Adapeter to Get the Data from Database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //DataTable to Hold the data from database temporarily
                DataTable dt = new DataTable();

                //Filld the data from adapter to dt
                adapter.Fill(dt);

                //Chekc whether user exists or not
                if (dt.Rows.Count > 0)
                {
                    //User Exists and Login Successful
                    isSuccess = true;
                    Console.WriteLine("LOGIN SUCCESSFUL");
                }
                else
                {
                    //Login Failed
                    isSuccess = false;
                    Console.WriteLine("LOGIN FAILED");
                }

            }
            catch (Exception ex)
            {
                //Display Error Message if there's any Exception Errors
                Console.WriteLine (ex.Message);
                Console.WriteLine ("LOGIN FAILED");
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }

            return isSuccess;
        }


    }
}
