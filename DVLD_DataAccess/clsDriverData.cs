using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsDriverData
    {
        public static bool GetDriverInfoByDriverID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            string Query = @"SELECT [PersonID]
                                    ,[CreatedByUserID]
                                    ,[CreatedDate]
                            FROM [dbo].[Drivers]
                            WHERE [DriverID] = @DriverID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@DriverID", DriverID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            PersonID = (int)Reader["PersonID"];
                            CreatedByUserID = (int)Reader["CreatedByUserID"];
                            CreatedDate = (DateTime)Reader["CreatedDate"];
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            string Query = @"SELECT [DriverID], [CreatedByUserID], [CreatedDate]
                            FROM [dbo].[Drivers]
                            WHERE [PersonID] = @PersonID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@PersonID", PersonID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            DriverID = (int)Reader["DriverID"];
                            CreatedByUserID = (int)Reader["CreatedByUserID"];
                            CreatedDate = (DateTime)Reader["CreatedDate"];
                            return true;
                        }
                        else
                            return false;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            string Query = @"INSERT INTO [dbo].[Drivers] ([PersonID], [CreatedByUserID], [CreatedDate])
                            VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@PersonID", PersonID);
                Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                Command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                try
                {
                    Connection.Open();
                    object Result = Command.ExecuteScalar();
                    if (Result != null && int.TryParse(Result.ToString(), out int DriverID))
                        return DriverID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    
                }
                return -1;
            }
        }

        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {
            string Query = @"UPDATE [dbo].[Drivers]
                            SET [PersonID] = @PersonID,
                                [CreatedByUserID] = @CreatedByUserID
                            WHERE [DriverID] = @DriverID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@DriverID", DriverID);
                Command.Parameters.AddWithValue("@PersonID", PersonID);
                Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                try
                {
                    Connection.Open();
                    return Command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public static bool DeleteDriver(int DriverID)
        {
            string Query = @"DELETE FROM [dbo].[Drivers] WHERE [DriverID] = @DriverID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@DriverID", DriverID);
                try
                {
                    Connection.Open();
                    return Command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public static bool IsDriverExist(int DriverID)
        {
            string Query = @"SELECT Found=1 FROM [dbo].[Drivers] WHERE [DriverID] = @DriverID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@DriverID", DriverID);
                try
                {
                    Connection.Open();
                    return Command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public static DataTable GetAllDrivers()
        {
            DataTable Drivers = new DataTable();
            string Query = @"SELECT [DriverID], [PersonID], [CreatedByUserID], [CreatedDate]
                            FROM [dbo].[Drivers];";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                        Drivers.Load(Reader);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return Drivers;
        }
        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            //for now this method here
            DataTable Drivers = new DataTable();
            string Query = @"SELECT    InternationalLicenseID, ApplicationID,
		                IssuedUsingLocalLicenseID , IssueDate, 
                        ExpirationDate, IsActive FROM [dbo].[InternationalLicenses] where DriverID = @DriverID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("DriverID", DriverID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                        Drivers.Load(Reader);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return Drivers;
        }
    }
}
