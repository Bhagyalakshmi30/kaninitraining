using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Numerics;

namespace BloodBank
{
    internal class DBuser
    {
        private string connection_string = @"Data source=DESKTOP-A8F8FKV\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=SSPI";
        public DataTable Select()
        {
            //Create an Object to connect database
            SqlConnection conn = new SqlConnection(connection_string);

            //Create a DataTable to Hold the Data from Database
            DataTable dt = new DataTable();

            try
            {
                // WRite SQL Qery to Get Data from Database
                String sql = "SELECT * FROM users";

                //Create SQL Command to Execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create Sql Data Adapter to hold the data from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();

                //Transfer Data from SqlData Adapter to DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Display Error Message if there's any exceptional errors
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }
            return dt;
        }

        public bool Insert(string? username, string? email, string? phone, string? password, string? full_name, string? address,DateTime addeddate )
        {
            //Create a boolean variable and set its default value to false
            bool isSuccess = false;

            //Create an Object of SqlConnection to connect Database
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                //Create a String Variable to Store the INSERT Query
                String sql = "INSERT INTO users(username, email,phone, password, fullname, address, addeddate) VALUES (@username, @email,@phone, @password, @fullname, @address, @addeddate)";

                //Create a SQL Command to pass the value in our query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create the Parameter to pass get the value from UI and pass it on SQL Query above
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@fullname", full_name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@addeddate",addeddate);
                

                //Open Database Connection
                conn.Open();

                //Create an Integer VAriable to hold the value after the query is executed
                int rows = cmd.ExecuteNonQuery();

                //The value of rows will be greater than 0 if the query is executed successfully
                //Else it'll be 0

                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                    Console.WriteLine("USER INSERTED SUCCESSFULLY");
                }
                else
                {
                    //FAiled to Execute Query
                    isSuccess = false;
                    Console.WriteLine("USER NOT INSERTED");
                }
            }
            catch (Exception ex)
            {
                //DIsplay Error Message if there's any exceptional errors
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }

            return isSuccess;
        }


        public bool Update(string? username, string? email, string? phone, string? password, string? fullname, string? address, DateTime addeddate,int user_id)
        {
            //Create a Boolean variable and set its default value to false
            bool isSuccess = false;

            //Create an Object for Database Connection
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                //Create a string variable to hold the sql query
                string sql = "UPDATE USERS SET username=@username, email=@email, phone=@phone, password=@password, fullname=@fullname, address=@address, addeddate=@addeddate WHERE user_id=@user_id";

                //Create Sql Command to execute query and also pass the values to sql query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Now Pass the values to SQL Query
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password",password);
                cmd.Parameters.AddWithValue("@fullname", fullname);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@addeddate", addeddate);
               
                cmd.Parameters.AddWithValue("@user_id", user_id);

                //open Database Connection
                conn.Open();

                //Create an integer variable to hold the value after the query is executed
                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then the value of rows will be greater than 0
                //else it'll be 0

                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                    Console.WriteLine("UPDATED SUCCESSFULLY");

                }
                else
                {
                    //Failed to Execute Query
                    isSuccess = false;
                    Console.WriteLine("NOT UPDATED");
                }
            }
            catch (Exception ex)
            {
                //Display error message if there's any exceptional error
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }

            return isSuccess;
        }

        public bool Delete(int user_id )
        {
            //Create a boolean variable and set its default value to false
            bool isSuccess = false;

            //Create an object for SqlConnection
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                //Create a string variable to hold the sql query to delete data
                String sql = "DELETE FROM users WHERE user_id=@user_id";

                //Create Sql Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pass the value thorugh parameters
                cmd.Parameters.AddWithValue("@user_id", user_id);

                //Open the DAtabase Connection
                conn.Open();

                //Create an integer variable to hold the value after query is executed
                int rows = cmd.ExecuteNonQuery();

                //If the query is executed Successfully then the value of rows will be greater than zero(0)
                //Else it'll be zero(0)

                if (rows > 0)
                {
                    //Query executed Successfully
                    isSuccess = true;
                    Console.WriteLine("USER DELETED SUCCESSFULLY");

                }
                else
                {
                    //Failed to Execute Query
                    isSuccess = false;
                    Console.WriteLine("NOT DELETED");
                }
            }
            catch (Exception ex)
            {
                //Display Error Message if there's any Excetionl errors
                Console.WriteLine(ex.Message);
            }
            finally
            {

                //CLose Database Connection
                conn.Close();
            }

            return isSuccess;
        }

        public DataTable Search(string keywords)
        {
            //1. Create an SQL Connection to connect database
            SqlConnection conn = new SqlConnection(connection_string);

            // 2. Create Data Table to Hold the data from database temporarily
            DataTable dt = new DataTable();

            //Write the Code to SEarh the Users
            try
            {
                // Write the SQL Query to SEarch the User from DAtabaes
                String sql = "SELECT * FROM USERS WHERE user_id LIKE '%" + keywords + "%' OR fullname LIKE '%" + keywords + "%' OR address LIKE '%" + keywords + "%'";

                //Create SQL Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create SQL DAta Adapter to Get the DAta from Database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open Database Connetion
                conn.Open();
                //Pass the data from adapter to dataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Display Error Messages if there's any exceptional errors
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Close the DAtabase Connection
                conn.Close();
            }

            return dt;
        }

        public User GetIDFromUsername(string username)
        {
            User u = new User();
            

            //Create SQL Connecction to Connect Database
            SqlConnection conn = new SqlConnection(connection_string);

            //DataTable to hold the data from database temporarily
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to get the ID from USERNAME
                string sql = "SELECT user_id FROM users WHERE username='" + username + "'";

                //Create SQL Data Adapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                //Open Database Connection
                conn.Open();

                //Fill the data in dataTable from Adapter
                adapter.Fill(dt);

                //If there's user based on the username then get the user_id
                if (dt.Rows.Count > 0)
                {
                    u.user_id = int.Parse(dt.Rows[0]["user_id"].ToString());
                }
            }
            catch (Exception ex)
            {
                //Display Error Message if there's any exceptional errors
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }

            return u;
        }

    }
}
