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
    public class clsLicenseData
    {

        public static bool GetLicense(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees,
            ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            string Query = @"SELECT [ApplicationID]
                                    ,[DriverID]
                                    ,[LicenseClass]
                                    ,[IssueDate]
                                    ,[ExpirationDate]
                                    ,[Notes]
                                    ,[PaidFees]
                                    ,[IsActive]
                                    ,[IssueReason]
                                    ,[CreatedByUserID]
                            FROM [dbo].[Licenses]
                            WHERE [LicenseID] = @LicenseID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LicenseID", LicenseID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            ApplicationID = (int)Reader["ApplicationID"];
                            DriverID = (int)Reader["DriverID"];
                            LicenseClass = (int)Reader["LicenseClass"];
                            IssueDate = (DateTime)Reader["IssueDate"];
                            ExpirationDate = (DateTime)Reader["ExpirationDate"];
                            Notes = (string)Reader["Notes"];
                            PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                            IsActive = (bool)Reader["IsActive"];
                            IssueReason = (byte)Reader["IssueReason"];
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



        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
             DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees,
             bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            string Query = @"INSERT INTO [dbo].[Licenses]
                                    ([ApplicationID]
                                    ,[DriverID]
                                    ,[LicenseClass]
                                    ,[IssueDate]
                                    ,[ExpirationDate]
                                    ,[Notes]
                                    ,[PaidFees]
                                    ,[IsActive]
                                    ,[IssueReason]
                                    ,[CreatedByUserID])
                            VALUES
                                    (@ApplicationID
                                    ,@DriverID
                                    ,@LicenseClass
                                    ,@IssueDate
                                    ,@ExpirationDate
                                    ,@Notes
                                    ,@PaidFees
                                    ,@IsActive
                                    ,@IssueReason
                                    ,@CreatedByUserID)
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                Command.Parameters.AddWithValue("@DriverID", DriverID);
                Command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                Command.Parameters.AddWithValue("@IssueDate", IssueDate);
                Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                Command.Parameters.AddWithValue("@Notes", Notes);
                Command.Parameters.AddWithValue("@PaidFees", PaidFees);
                Command.Parameters.AddWithValue("@IsActive", IsActive);
                Command.Parameters.AddWithValue("@IssueReason", IssueReason);
                Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                try
                {
                    Connection.Open();
                    object Result = Command.ExecuteScalar();
                    if (Result != null && int.TryParse(Result.ToString(), out int LicenseID))
                        return LicenseID;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());

                }
                return -1;
            }
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
             DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees,
             bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            string Query = @"UPDATE [dbo].[Licenses]
                            SET [ApplicationID] = @ApplicationID
                               ,[DriverID] = @DriverID
                               ,[LicenseClass] = @LicenseClass
                               ,[IssueDate] = @IssueDate
                               ,[ExpirationDate] = @ExpirationDate
                               ,[Notes] = @Notes
                               ,[PaidFees] = @PaidFees, 
                               ,[IsActive] = @IsActive
                               ,[IssueReason] = @IssueReason
                               ,[CreatedByUserID] = @CreatedByUserID
                             WHERE [LicenseID] = @LicenseID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                Command.Parameters.AddWithValue("@DriverID", DriverID);
                Command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                Command.Parameters.AddWithValue("@IssueDate", IssueDate);
                Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                Command.Parameters.AddWithValue("@Notes", Notes);
                Command.Parameters.AddWithValue("@PaidFees", PaidFees);
                Command.Parameters.AddWithValue("@IsActive", IsActive);
                Command.Parameters.AddWithValue("@IssueReason", IssueReason);
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

        public static bool DeleteLicense(int LicenseID)
        {
            string Query = @"DELETE FROM [dbo].[Licenses] WHERE [LicenseID] = @LicenseID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LicenseID", LicenseID);
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

        public static bool IsLicenseExist(int LicenseID)
        {
            string Query = @"SELECT Found=1 FROM [dbo].[Licenses] WHERE [LicenseID] = @LicenseID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LicenseID", LicenseID);
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

        public static DataTable GetAllLicenses()
        {
            DataTable Licenses = new DataTable();
            string Query = @"SELECT *
                            FROM [dbo].[Licenses];";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                        Licenses.Load(Reader);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return Licenses;
        }
    }
}
