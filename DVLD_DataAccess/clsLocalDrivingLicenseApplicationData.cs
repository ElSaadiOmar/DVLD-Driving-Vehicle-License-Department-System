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
    public class clsLocalDrivingLicenseApplicationData
    {
        public static bool GetLocalDrivingLicenseApplicationInfo(int ID, ref int ApplicationID, ref int LicenseClassID)
        {
            string Query = @"SELECT * FROM [LocalDrivingLicenseApplications] where [LocalDrivingLicenseApplicationID] = @ID";
            
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            ApplicationID = (int)Reader["ApplicationID"];
                            LicenseClassID = (int)Reader["LicenseClassID"];
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
        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            string Query = @"SELECT * FROM [LocalDrivingLicenseApplications] where [ApplicationID] = @ApplicationID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                            LicenseClassID = (int)Reader["LicenseClassID"];
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


        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID,  int LicenseClassID)
        {

            string Query = @"INSERT INTO [dbo].[LocalDrivingLicenseApplications]
                                ([ApplicationID]
                                ,[LicenseClassID])
                             VALUES
                                (@ApplicationID,
                                 @LicenseClassID)
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                
                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                try
                {
                    Connection.Open();
                    object result = Command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        return insertedID;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return -1;
                }
                return -1;
            }
        }

        public static bool UpdateLocalDrivingLicenseApplication(int ID,int ApplicationID, int LicenseClassID)
        {
            string Query = @"UPDATE [dbo].[LocalDrivingLicenseApplications]
                                  SET [ApplicationID] = @ApplicationID
                                     ,[LicenseClassID] = @LicenseClassID
                                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);
                try
                {
                    Connection.Open();
                    int RowAffected = Command.ExecuteNonQuery();
                    return RowAffected > 0;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
                
        public static bool DeleteLocalDrivingLicenseApplication(int ID)
        {
            string Query = @"DELETE FROM [dbo].[LocalDrivingLicenseApplications]
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);
                try
                {
                    Connection.Open();
                    int RowAffected = Command.ExecuteNonQuery();
                    return RowAffected > 0;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }

        }
       
        public static bool IsLocalDrivingLicenseApplicationExist(int ID)
        {
            string Query = @"select Found=1 from [dbo].[LocalDrivingLicenseApplications] 
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);
                try
                {
                    Connection.Open();
                    object Result = Command.ExecuteScalar();
                    return Result != null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
       
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            string Query = @"SELECT [LocalDrivingLicenseApplicationID]
                                  ,[ClassName]
                                  ,[NationalNo]
                                  ,[FullName]
                                  ,[ApplicationDate]
                                  ,[PassedTestCount]
                                  ,[Status]
                              FROM [dbo].[LocalDrivingLicenseApplications_View]
Order By LocalDrivingLicenseApplicationID DESC";
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

        public static int GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"SELECT COUNT(*) as PassedTestCount
                     FROM [dbo].[TestAppointments]
                     inner join [Tests] on [TestAppointments].TestAppointmentID = [Tests].TestAppointmentID
                     where [TestAppointments].LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                     and [Tests].TestResult=1;";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                try
                {
                    Connection.Open();
                    object Result = Command.ExecuteScalar();
                    if (Result != null && int.TryParse(Result.ToString(), out int PassedTestCount))
                    {
                        return PassedTestCount;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return 0;
                }
            }
        }


    }
}
