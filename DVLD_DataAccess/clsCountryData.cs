using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsCountryData
    {
        public static bool GetCountryInfoByID(int ID, ref string CountryName)
        {

            string Query = @"SELECT [CountryID],[CountryName] FROM [dbo].[Countries] WHERE CountryID = @CountryID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, Connection)) 
            { 

                command.Parameters.AddWithValue("@CountryID", ID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            CountryName = (string)reader["CountryName"];
                            return true;
                        }
                        else
                        {
                            // The record was not found
                            return  false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }


        public static bool GetCountryInfoByName(string CountryName, ref int ID)
        {

            string Query = @"SELECT [CountryID],[CountryName] FROM [dbo].[Countries] WHERE CountryName = @CountryName";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, Connection))
            {

                command.Parameters.AddWithValue("@CountryName", CountryName);
                try
                {
                    Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            ID = (int)reader["CountryID"];
                            return true;
                        }
                        else
                        {
                            // The record was not found
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }



        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();

            string query = "SELECT * FROM Countries order by CountryName";
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    // Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
        }
    
        public static bool IsCountryExist(int ID)
        {

            string query = "SELECT Found=1 FROM Countries WHERE CountryID = @CountryID";

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection)) 
            {

                command.Parameters.AddWithValue("@CountryID", ID);
                try
                {
                    connection.Open();
                    object Result = command.ExecuteScalar();
                    return Result != null;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }

        }


        public static bool IsCountryExist(string CountryName)
        {
            
            string query = "SELECT Found=1 FROM Countries WHERE CountryName = @CountryName";

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@CountryName", CountryName);
                try
                {
                    connection.Open();
                    object Result = command.ExecuteScalar();
                    return Result != null;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }

        }

    }
}
