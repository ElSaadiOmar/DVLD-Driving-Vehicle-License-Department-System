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
    public class clsUserData
    {
        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            string Query = @"SELECT * FROM [dbo].[Users] where Users.UserID = @UserID;";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            PersonID = (int)Reader["PersonID"];
                            UserName = (string)Reader["UserName"];
                            Password = (string)Reader["Password"];
                            IsActive = (bool)Reader["IsActive"];
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
        public static bool GetUserInfoByUserName(  string UserName , ref int UserID, ref int PersonID, ref string Password, ref bool IsActive)
        {
            string Query = @"SELECT * FROM [dbo].[Users] where Users.UserName = @UserName;";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@UserName", UserName);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            UserID = (int)Reader["UserID"];
                            PersonID = (int)Reader["PersonID"];
                            Password = (string)Reader["Password"];
                            IsActive = (bool)Reader["IsActive"];
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

        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password, ref bool IsActive)
        {
            string Query = @"SELECT * FROM [dbo].[Users] where Users.PersonID = @PersonID;";
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
                            UserID = (int)Reader["UserID"];
                            UserName = (string)Reader["UserName"];
                            Password = (string)Reader["Password"];
                            IsActive = (bool)Reader["IsActive"];
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
        public static bool GetUserInfoByUserNameAndPassword(string UserName, string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            string Query = @"SELECT * FROM [dbo].[Users] where 
                                USERs.UserName = @UserName COLLATE Latin1_General_CS_AS
                                and 
                                Users.Password = @Password COLLATE Latin1_General_CS_AS;";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@UserName", UserName);
                Command.Parameters.AddWithValue("@Password", Password);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            UserID = (int)Reader["UserID"];
                            PersonID = (int)Reader["PersonID"];
                            IsActive = (bool)Reader["IsActive"];
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

        public static int AddNewUser(int PersonID,string UserName,string Password,bool IsActive)
        {

            string Query = @"INSERT INTO [dbo].[Users]
                                    ([PersonID]
                                    ,[UserName]
                                    ,[Password]
                                    ,[IsActive])
                            VALUES
                                    (@PersonID,
                                    @UserName,
                                    @Password,
                                    @IsActive);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                if(string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
                {
                    return -1;
                }
                Command.Parameters.AddWithValue("@PersonID", PersonID);
                Command.Parameters.AddWithValue("@UserName", UserName);
                Command.Parameters.AddWithValue("@Password", Password);
                Command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            string Query = @"UPDATE [dbo].[Users]
                             SET [PersonID] = @PersonID
                                ,[UserName] = @UserName
                                ,[Password] = @Password
                                ,[IsActive] = @IsActive
                           WHERE Users.UserID = @UserID;";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
                {
                    return false;
                }
                Command.Parameters.AddWithValue("@UserID", UserID);
                Command.Parameters.AddWithValue("@PersonID", PersonID);
                Command.Parameters.AddWithValue("@UserName", UserName);
                Command.Parameters.AddWithValue("@Password", Password);
                Command.Parameters.AddWithValue("@IsActive", IsActive);
                try
                {
                    Connection.Open();
                    int RowAfficted = Command.ExecuteNonQuery();
                    return RowAfficted > 0;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }

            }

        }

        public static bool DeleteUserByPersonID(int PersonID)
        {
            string Query = @"DELETE FROM [dbo].[Users]
                        WHERE PersonID = @PersonID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@PersonID", PersonID);
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
        public static bool DeleteUser(int UserID)
        {
            string Query = @"DELETE FROM [dbo].[Users]
                           WHERE Users.UserID = @UserID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@UserID", UserID);
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

        public static bool IsUserExist(int UserID)
        {
            string Query = "select Found=1 from [dbo].[Users] where UserID = @UserID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@UserID", UserID);
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
        public static bool IsUserExist(string UserName)
        {
            string Query = "select Found=1 from [dbo].[Users] where UserName = @UserName COLLATE Latin1_General_CS_AS";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@UserName", UserName);
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

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            string Query = @"SELECT  Users.UserID, Users.PersonID,
                            FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL( People.ThirdName,'') +' ' + People.LastName,
                             Users.UserName, Users.IsActive
                             FROM  Users INNER JOIN
                                    People ON Users.PersonID = People.PersonID
                        order by UserID";
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

        public static bool IsUserExistForPersonID(int PersonID)
        {
            string Query = "Select Found=1 from [dbo].[Users] where PersonID = @PersonID;";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@PersonID", PersonID);
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
    }
}
