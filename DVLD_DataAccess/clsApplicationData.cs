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
    public class clsApplicationData
    {
        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate,
            ref int ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            string Query = @"SELECT [ApplicationID]
                            ,[ApplicantPersonID]
                            ,[ApplicationDate]
                            ,[ApplicationTypeID]
                            ,[ApplicationStatus]
                            ,[LastStatusDate]
                            ,[PaidFees]
                            ,[CreatedByUserID]
                            FROM [dbo].[Applications]
                            WHERE ApplicationID = @ApplicationID";

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
                            ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                            ApplicationDate = (DateTime)Reader["ApplicationDate"];
                            ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                            ApplicationStatus = (byte)Reader["ApplicationStatus"];
                            LastStatusDate = (DateTime)Reader["LastStatusDate"];
                            PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                            CreatedByUserID = (int)Reader["CreatedByUserID"];
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
        public static bool GetApplicationInfoByApplicantPersonIDAndLicenseClassID(int ApplicantPersonID, int LicenseClassID, ref int ApplicationID, ref DateTime ApplicationDate,
            ref int ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            string Query = @"SELECT Applications.* FROM [dbo].[Applications] 
                               inner join LocalDrivingLicenseApplications LDLA 
                           On LDLA.ApplicationID = Applications.ApplicationID where LDLA.LicenseClassID = @LicenseClassID 
                          and Applications.ApplicantPersonID = @ApplicantPersonID and Applications.ApplicationStatus !=2";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            ApplicationID = (int)Reader["ApplicationID"];
                            ApplicationDate = (DateTime)Reader["ApplicationDate"];
                            ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                            ApplicationStatus = (byte)Reader["ApplicationStatus"];
                            LastStatusDate = (DateTime)Reader["LastStatusDate"];
                            PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                            CreatedByUserID = (int)Reader["CreatedByUserID"];
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

        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            string Query = @"INSERT INTO [dbo].[Applications]
                                ([ApplicantPersonID]
                                ,[ApplicationDate]
                                ,[ApplicationTypeID]
                                ,[ApplicationStatus]
                                ,[LastStatusDate]
                                ,[PaidFees]
                                ,[CreatedByUserID])
                             VALUES
                                (@ApplicantPersonID,
                                 @ApplicationDate,
                                 @ApplicationTypeID,
                                 @ApplicationStatus,
                                 @LastStatusDate,
                                 @PaidFees,
                                 @CreatedByUserID)
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                Command.Parameters.AddWithValue("@PaidFees", PaidFees);
                Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
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

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            string Query = @"UPDATE [dbo].[Applications]
                            SET [ApplicantPersonID] = @ApplicantPersonID,
                                [ApplicationDate] = @ApplicationDate,
                                [ApplicationTypeID] = @ApplicationTypeID,
                                [ApplicationStatus] = @ApplicationStatus,
                                [LastStatusDate] = @LastStatusDate,
                                [PaidFees] = @PaidFees,
                                [CreatedByUserID] = @CreatedByUserID
                            WHERE ApplicationID = @ApplicationID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                Command.Parameters.AddWithValue("@PaidFees", PaidFees);
                Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                try
                {
                    Connection.Open();
                    int RowsAffected = Command.ExecuteNonQuery();
                    return RowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            string Query = @"DELETE FROM [dbo].[Applications]
                            WHERE ApplicationID = @ApplicationID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                try
                {
                    Connection.Open();
                    int RowsAffected = Command.ExecuteNonQuery();
                    return RowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public static DataTable GetAllApplications()
        {
            string Query = "SELECT * FROM [dbo].[Applications]";
            DataTable dt = new DataTable();

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

        public static bool IsApplicationExists(int ApplicationID)
        {
            string Query = @"SELECT COUNT(*) FROM [dbo].[Applications]
                            WHERE ApplicationID = @ApplicationID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                try
                {
                    Connection.Open();
                    object result = Command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int count))
                    {
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
                return false;
            }
        }
        public static bool UpdateStatus(int ApplicationID,int NewStatus)
        {
            string Query = @"UPDATE [dbo].[Applications]
                             SET
                             [ApplicationStatus] = @NewStatus
                            ,[LastStatusDate] = @LastStatusDate
                             WHERE [ApplicationID] = @ApplicationID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                Command.Parameters.AddWithValue("@NewStatus", NewStatus);
                Command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
                try
                {
                    Connection.Open();
                    int RowsAffected = Command.ExecuteNonQuery();
                    return RowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
    }
}
