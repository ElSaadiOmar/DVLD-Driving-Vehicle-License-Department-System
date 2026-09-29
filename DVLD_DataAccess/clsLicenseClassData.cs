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
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfoByID(int LicenseClassID, ref string ClassName, ref string ClassDescription, 
            ref int MinimumAllowedAge, ref int DefaultValidityLength, ref float ClassFees)
        {
            string Query = @"SELECT [LicenseClassID]
                            ,[ClassName]
                            ,[ClassDescription]
                            ,[MinimumAllowedAge]
                            ,[DefaultValidityLength]
                            ,[ClassFees]
                            FROM [dbo].[LicenseClasses]
                            WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            ClassName = (string)Reader["ClassName"];
                            ClassDescription = (string)Reader["ClassDescription"];
                            MinimumAllowedAge = (int)Reader["MinimumAllowedAge"];
                            DefaultValidityLength = (int)Reader["DefaultValidityLength"];
                            ClassFees = Convert.ToSingle(Reader["ClassFees"]);
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

        public static bool GetLicenseClassInfoByName(string ClassName, ref int LicenseClassID, ref string ClassDescription,
            ref int MinimumAllowedAge, ref int DefaultValidityLength, ref float ClassFees)
        {
            string Query = @"SELECT [LicenseClassID]
                            ,[ClassName]
                            ,[ClassDescription]
                            ,[MinimumAllowedAge]
                            ,[DefaultValidityLength]
                            ,[ClassFees]
                            FROM [dbo].[LicenseClasses]
                            WHERE ClassName = @ClassName";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ClassName", ClassName);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            LicenseClassID = (int)Reader["LicenseClassID"];
                            ClassDescription = (string)Reader["ClassDescription"];
                            MinimumAllowedAge = (int)Reader["MinimumAllowedAge"];
                            DefaultValidityLength = (int)Reader["DefaultValidityLength"];
                            ClassFees = Convert.ToSingle(Reader["ClassFees"]);
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

        public static int AddNewLicenseClass(string ClassName, string ClassDescription, int MinimumAllowedAge, 
            int DefaultValidityLength, float ClassFees)
        {
            string Query = @"INSERT INTO [dbo].[LicenseClasses]
                                ([ClassName]
                                ,[ClassDescription]
                                ,[MinimumAllowedAge]
                                ,[DefaultValidityLength]
                                ,[ClassFees])
                             VALUES
                                (@ClassName,
                                 @ClassDescription,
                                 @MinimumAllowedAge,
                                 @DefaultValidityLength,
                                 @ClassFees)
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ClassName", ClassName);
                Command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                Command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                Command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                Command.Parameters.AddWithValue("@ClassFees", ClassFees);
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

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription, 
            int MinimumAllowedAge, int DefaultValidityLength, float ClassFees)
        {
            string Query = @"UPDATE [dbo].[LicenseClasses]
                            SET [ClassName] = @ClassName,
                                [ClassDescription] = @ClassDescription,
                                [MinimumAllowedAge] = @MinimumAllowedAge,
                                [DefaultValidityLength] = @DefaultValidityLength,
                                [ClassFees] = @ClassFees
                            WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                Command.Parameters.AddWithValue("@ClassName", ClassName);
                Command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                Command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                Command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                Command.Parameters.AddWithValue("@ClassFees", ClassFees);
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

        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            string Query = @"DELETE FROM [dbo].[LicenseClasses]
                            WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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

        public static DataTable GetAllLicenseClasses()
        {
            string Query = "SELECT * FROM [dbo].[LicenseClasses]";
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

        public static bool IsLicenseClassExists(int LicenseClassID)
        {
            string Query = @"SELECT COUNT(*) FROM [dbo].[LicenseClasses]
                            WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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
    }
}
