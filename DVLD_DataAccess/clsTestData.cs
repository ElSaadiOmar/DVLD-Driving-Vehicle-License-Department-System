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
    public class clsTestData
    {
        public static bool GetTestByTestID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            string Query = @"SELECT [TestID]
                            ,[TestAppointmentID]
                            ,[TestResult]
                            ,[Notes]
                            ,[CreatedByUserID]
                            FROM [dbo].[Tests] 
                            WHERE TestID = @TestID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestID", TestID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            TestAppointmentID = (int)Reader["TestAppointmentID"];
                            TestResult = (bool)Reader["TestResult"];
                            Notes = Reader["Notes"] != DBNull.Value ? (string)Reader["Notes"] : "";
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

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            string Query = @"INSERT INTO [dbo].[Tests]
                            ([TestAppointmentID]
                            ,[TestResult]
                            ,[Notes]
                            ,[CreatedByUserID])
                            VALUES
                            (@TestAppointmentID
                            ,@TestResult
                            ,@Notes
                            ,@CreatedByUserID);
                            Update [TestAppointments] 
                            set IsLocked =1 where TestAppointmentID = @TestAppointmentID;
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                Command.Parameters.AddWithValue("@TestResult", TestResult);

                if (string.IsNullOrWhiteSpace(Notes))
                    Command.Parameters.AddWithValue("@Notes", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@Notes", Notes);

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

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            string Query = @"UPDATE [dbo].[Tests]
                            SET [TestAppointmentID] = @TestAppointmentID
                               ,[TestResult] = @TestResult
                               ,[Notes] = @Notes
                               ,[CreatedByUserID] = @CreatedByUserID
                            WHERE TestID = @TestID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestID", TestID);
                Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                Command.Parameters.AddWithValue("@TestResult", TestResult);

                if (string.IsNullOrWhiteSpace(Notes))
                    Command.Parameters.AddWithValue("@Notes", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@Notes", Notes);

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

        public static bool DeleteTest(int TestID)
        {
            string Query = @"DELETE FROM [dbo].[Tests]
                            WHERE TestID = @TestID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestID", TestID);
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

        public static DataTable GetAllTests()
        {
            string Query = "SELECT * FROM [dbo].[Tests]";
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

        public static bool IsTestExist(int TestID)
        {
            string Query = "SELECT Found=1 FROM [dbo].[Tests] WHERE TestID = @TestID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestID", TestID);
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

        public static bool GetTestsByTestAppointmentID(int TestAppointmentID, ref int TestID, ref bool TestResult, ref string Notes,
            ref int CreatedByUserID)
        {
            string Query = @"SELECT [TestID]
                            ,[TestAppointmentID]
                            ,[TestResult]
                            ,[Notes]
                            ,[CreatedByUserID]
                            FROM [dbo].[Tests] 
                            WHERE TestAppointmentID = @TestAppointmentID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            TestID = (int)Reader["TestID"];
                            TestResult = (bool)Reader["TestResult"];
                            Notes = Reader["Notes"] != DBNull.Value ? (string)Reader["Notes"] : "";
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


        public static DataTable GetTestsByCreatedByUserID(int CreatedByUserID)
        {
            string Query = @"SELECT * FROM [dbo].[Tests] 
                            WHERE CreatedByUserID = @CreatedByUserID";
            DataTable dt = new DataTable();
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
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





