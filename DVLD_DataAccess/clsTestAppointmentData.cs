using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestAppointmentData
    {
        
        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, 
            DateTime AppointmentDate, float PaidFees, int CreatedByUserID, 
            bool IsLocked, int? RetakeTestApplicationID = null)
        {
            string Query = @"INSERT INTO [dbo].[TestAppointments]
                                    ([TestTypeID]
                                    ,[LocalDrivingLicenseApplicationID]
                                    ,[AppointmentDate]
                                    ,[PaidFees]
                                    ,[CreatedByUserID]
                                    ,[IsLocked]
                                    ,[RetakeTestApplicationID])
                            VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, 
                                    @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                Command.Parameters.AddWithValue("@PaidFees", PaidFees);
                Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                Command.Parameters.AddWithValue("@IsLocked", IsLocked);
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID ?? (object)DBNull.Value);

                try
                {
                    Connection.Open();
                    object result = Command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        return id;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return -1;
                }
            }
            return -1; // Return -1 to indicate failure

        }

        
        public static bool GetTestAppointmentByAppointmentID(int TestAppointmentID,ref int TestTypeID,ref int LocalDrivingLicenseApplicationID,
           ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref
            bool IsLocked, ref int? RetakeTestApplicationID )
        {
            string Query = @"SELECT 
                            [TestAppointmentID], [TestTypeID], [LocalDrivingLicenseApplicationID], 
                            [AppointmentDate], [PaidFees], [CreatedByUserID], [IsLocked], [RetakeTestApplicationID]
                            FROM [dbo].[TestAppointments] 
                            WHERE [TestAppointmentID] = @TestAppointmentID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if(Reader.Read())
                        {
                            TestTypeID = (int)Reader["TestTypeID"];
                            LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                            AppointmentDate = (DateTime)Reader["AppointmentDate"];
                            PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                            CreatedByUserID = (int)Reader["CreatedByUserID"];
                            IsLocked = (bool)Reader["IsLocked"];
                            RetakeTestApplicationID = Reader["RetakeTestApplicationID"] != DBNull.Value ? (int)Reader["RetakeTestApplicationID"] : (int?)null;
                            return true;
                        }
                        else
                        {
                            return false; // No record found
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

        public static bool GetTestAppointmentByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID, ref int TestAppointmentID, ref int TestTypeID,
          ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref
           bool IsLocked, ref int? RetakeTestApplicationID)
        {
            string Query = @"SELECT 
                            [TestAppointmentID], [TestTypeID], [LocalDrivingLicenseApplicationID], 
                            [AppointmentDate], [PaidFees], [CreatedByUserID], [IsLocked], [RetakeTestApplicationID]
                            FROM [dbo].[TestAppointments] 
                            WHERE [LocalDrivingLicenseApplicationID] = @LocalDrivingLicenseApplicationID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            TestAppointmentID = (int)Reader["TestAppointmentID"];
                            TestTypeID = (int)Reader["TestTypeID"];
                            AppointmentDate = (DateTime)Reader["AppointmentDate"];
                            PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                            CreatedByUserID = (int)Reader["CreatedByUserID"];
                            IsLocked = (bool)Reader["IsLocked"];
                            RetakeTestApplicationID = Reader["RetakeTestApplicationID"] != DBNull.Value ? (int)Reader["RetakeTestApplicationID"] : (int?)null;
                            return true;
                        }
                        else
                        {
                            return false; // No record found
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

        public static DataTable GetApplicationTestAppointments(int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            string Query = @"SELECT 
                            [TestAppointmentID], [TestTypeID], [LocalDrivingLicenseApplicationID], 
                            [AppointmentDate], [PaidFees], [CreatedByUserID], [IsLocked], [RetakeTestApplicationID]
                            FROM [dbo].[TestAppointments] 
                            WHERE [LocalDrivingLicenseApplicationID] = @LocalDrivingLicenseApplicationID
                            ORDER BY [AppointmentDate] DESC";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        dt.Load(Reader);
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return dt;
                }
            }
        }

       
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();
            string Query = @"SELECT 
                            [TestAppointmentID],  [AppointmentDate], [PaidFees], [IsLocked]
                            FROM [dbo].[TestAppointments] 
                            WHERE [LocalDrivingLicenseApplicationID] = @LocalDrivingLicenseApplicationID 
                            AND [TestTypeID] = @TestTypeID
                            ORDER BY [TestAppointmentID] DESC";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        dt.Load(Reader);
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return dt;
                }
            }
        }

        public static DataTable GetAllTestAppointments()
        {
            DataTable dt = new DataTable();
            string Query = @"SELECT 
                            [TestAppointmentID], [TestTypeID], [LocalDrivingLicenseApplicationID], 
                            [AppointmentDate], [PaidFees], [CreatedByUserID], [IsLocked], [RetakeTestApplicationID]
                            FROM [dbo].[TestAppointments]
                            ORDER BY [AppointmentDate] DESC";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        dt.Load(Reader);
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return dt;
                }
            }
        }

      
        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int? RetakeTestApplicationID = null)
        {
            string Query = @"UPDATE [dbo].[TestAppointments]
                            SET [TestTypeID] = @TestTypeID,
                                [LocalDrivingLicenseApplicationID] = @LocalDrivingLicenseApplicationID,
                                [AppointmentDate] = @AppointmentDate,
                                [PaidFees] = @PaidFees,
                                [CreatedByUserID] = @CreatedByUserID,
                                [IsLocked] = @IsLocked,
                                [RetakeTestApplicationID] = @RetakeTestApplicationID
                            WHERE [TestAppointmentID] = @TestAppointmentID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                Command.Parameters.AddWithValue("@PaidFees", PaidFees);
                Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                Command.Parameters.AddWithValue("@IsLocked", IsLocked);
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID ?? (object)DBNull.Value);

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

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            string Query = @"DELETE FROM [dbo].[TestAppointments]
                            WHERE [TestAppointmentID] = @TestAppointmentID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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
    
        public static int GetTestID(int TestAppointmentID)
        {
            string Query = @"SELECT  [TestID]
                            FROM [dbo].[Tests] inner join TestAppointments 
                            on TestAppointments.TestAppointmentID =Tests.TestAppointmentID
                            where Tests.TestAppointmentID = @TestAppointmentID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                try
                {
                    Connection.Open();
                    object result = Command.ExecuteScalar();
                    return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : -1;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return -1;
                }
            }
        }
    }
}
