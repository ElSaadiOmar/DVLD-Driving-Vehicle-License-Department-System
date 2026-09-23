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
    public class clsApplicationTypeData
    {
        public static bool GetApplicationTypeByID(int ApplicationTypeID, ref string ApplicationTypeTitle,ref float ApplicationFees)
        {
            string Query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            ApplicationTypeTitle = Reader["ApplicationTypeTitle"].ToString();
                            ApplicationFees = Convert.ToSingle(Reader["ApplicationFees"]);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
        public static bool UpdateApplicationType(int ApplicationTypeID,string ApplicationTypeTitle, float ApplicationFees)
        {
            string Query = @"UPDATE [dbo].[ApplicationTypes]
                SET
                    [ApplicationTypeTitle] = @ApplicationTypeTitle,
                    [ApplicationFees] = @ApplicationFees
                WHERE ApplicationTypeID = @ApplicationTypeID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                Command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                Command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
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
        public static DataTable GetAllApplicationType()
        {
            string Query = "Select * from ApplicationTypes";
            DataTable dt =new DataTable();
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
    }
}
