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
    public class clsTestTypeData
    {
        public static bool GetTestTypeByID(int TestTypeID, ref string TestTypeTitle,ref string TestTypeDescription, ref float TestFees)
        {
            string Query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            TestTypeTitle = Reader["TestTypeTitle"].ToString();
                            TestTypeDescription = Reader["TestTypeDescription"].ToString();
                            TestFees = Convert.ToSingle(Reader["TestTypeFees"]);
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
        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
       {
            string Query = @"UPDATE [dbo].[TestTypes]
                SET
                    [TestTypeTitle] = @TestTypeTitle,
                    [TestTypeDescription] = @TestTypeDescription,
                    [TestTypeFees] = @TestTypeFees
                WHERE TestTypeID = @TestTypeID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                Command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                Command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                Command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
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
        public static DataTable GetAllTestTypes()
        {
            string Query = "Select * from TestTypes";
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

    }
}
