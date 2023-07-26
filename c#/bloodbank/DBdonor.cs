using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank
{
    internal class DBdonor
    {
        private string connection_string = @"Data source=DESKTOP-A8F8FKV\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=SSPI";
        public DataTable Select()
        {
            // Create object to DataTAble to hold the data from database and return it
            DataTable dt = new DataTable();

            //Create object of SQL Connection to Connect DAtabase
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                //Write SQL Query to SElect the DAta from DAtabase
                string sql = "SELECT * FROM Donors";

                //Create the SQlCommand to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create SQl DAta Adapter to Hold the Data Temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open Database Connection
                conn.Open();

                //Pass the Data from adapter to DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Display Message if there's any Exceptional Errors
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }
            return dt;
        }

        public bool Insert( string? first_name, string? last_name, string? email, string? contact, string? gender, string? address, string? blood_group, DateTime added_date, int added_by)
        {
            //Create a Boolean Variable and SEt its default value to false
            bool isSuccess = false;

            //Create SqlConnection to Connect Database
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                //Write the Query to INSERT data into database
                string sql = "INSERT INTO donors (first_name, last_name, email, contact, gender, address, blood_group, added_date, added_by) VALUES (@first_name, @last_name, @email, @contact, @gender, @address, @blood_group, @added_date, @added_by)";

                //Create SQL Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pass the value to SQL Query
                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@blood_group", blood_group);
                cmd.Parameters.AddWithValue("@added_date", added_date);
                //cmd.Parameters.AddWithValue("@image_name", d.image_name);
                cmd.Parameters.AddWithValue("@added_by", added_by);

                //Open DAtabase Connection
                conn.Open();

                //Create an Integer Variable to Check whether the query was executed Successfully or Not
                int rows = cmd.ExecuteNonQuery();

                //If the Query is Executed Successfully the value of rows willb e greater than Zero else it will be Zero
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
                //Display Error Message if there's any Exceptional Errors
                Console.WriteLine (ex.Message);
            }
            finally
            {
                //CLose Database Connection
                conn.Close();
            }

            return isSuccess;
        }

        public bool Update(string? first_name, string? last_name, string? email, string? contact, string? gender, string? address, string? blood_group, DateTime added_date, int added_by,int donor_id)
        {
            //Create a Boolean Variable and SEt its Default Value to FAlse
            bool isSuccess = false;
            //Create SQLConnection to Connect DAtabase
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                //Create a SQL Query to Update Donors
                string sql = "UPDATE donors SET first_name=@first_name, last_name=@last_name, email=@email, contact=@contact, gender=@gender, address=@address, blood_group=@blood_group,  added_by=@added_by WHERE donor_id=@donor_id";

                //Create SQL Command Here
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pass the Value to SQL Query
                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@blood_group", blood_group);
                //cmd.Parameters.AddWithValue("@image_name",     d.image_name);
                cmd.Parameters.AddWithValue("@added_by", added_by);
                cmd.Parameters.AddWithValue("@donor_id", donor_id);

                //Open Database Connection
                conn.Open();

                //Create an Integer Variable to check whether the query executed Successfully or not
                int rows = cmd.ExecuteNonQuery();

                //If the Query is Executed Successfully then its value will be greater than 0 else it will be 0
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
                //Display Error Message if there's any exceptional errors
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //CLose Database Connection
                conn.Close();
            }

            return isSuccess;
        }

        
        
        public bool Delete( int donor_id)
        {
            //Create a Boolean variable and set its default value to false
            bool isSuccess = false;
            //Create SqlConnection To Connect DAtabase
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                //Write the Query to Delete Donors from Database
                string sql = "DELETE FROM donors WHERE donor_id=@donor_id";

                //Create SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pass the Value to Sql Query using Parameters
                cmd.Parameters.AddWithValue("@donor_id", donor_id);

                //Open Database Connection
                conn.Open();

                //Create an Integer VAriable to Check whether the query executed Successfully or Not
                int rows = cmd.ExecuteNonQuery();

                //If the Query executed succesfully then the value of rows will be greater than 0 else it will be 0
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                    Console.WriteLine("DELETED SUCCESSFULLY");
                }
                else
                {
                    //FAiled to Exeute Query
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                //Display Error Message if there's any Exceptional Errors
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //CLose Database Connection
                conn.Close();
            }

            return isSuccess;
        }


        public string countDonors(string blood_group)
        {
            //Create SQL Connection for Database Connection
            SqlConnection conn = new SqlConnection(connection_string);

            //Create astring variable for donor count and set its default value to 0
            string donors = "0";

            try
            {
                //SQL Query to Count donors for Specific Blood Group
                string sql = "SELECT * FROM donors WHERE blood_group = '" + blood_group + "'";

                //Sql Command to Execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Sql Data Adapter to Get the data from DAtabase
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Databale to Hold the DAta Temporarily
                DataTable dt = new DataTable();

                //Pass tehe value from SqlDataAdapter to DataTable
                adapter.Fill(dt);

                //Get the Total Number of Donors Based on Blood Group
                donors = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                //Display error message if there's any
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }

            return donors;
        }

        public DataTable Search(string keywords)
        {
            //1. SQL Connection to Connect DAtabase
            SqlConnection conn = new SqlConnection(connection_string);

            //2. Create DataTable to hold the data Temporarily
            DataTable dt = new DataTable();

            try
            {
                //Write the Code to Search Donors based on Keywords Typed on TextBox
                //Write SQL Query to SEarch Donors
                string sql = "SELECT * FROM donors WHERE donor_id LIKE '%" + keywords + "%' OR first_name LIKE '%" + keywords + "%' OR last_name LIKE '" + keywords + "' OR email LIKE '%" + keywords + "%' OR blood_group LIKE '" + keywords + "'";

                //Create SQL Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQlDataAdapter to Save Data from Database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();

                //Transfer the Data from SQL Data Adapter to DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Display Error Message if there's any Exceptional Errors
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Close the DAtabase Connection
                conn.Close();
            }

            return dt;
        }




    }
}
