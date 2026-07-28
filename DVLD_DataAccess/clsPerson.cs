using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(int ID,ref string NationalNo,
            ref string FirstName,ref string SecondName ,ref string ThirdName,ref string LastName,
            ref DateTime DateOfBirth,ref int Gender,ref string Address, ref string Email,
            ref string Phone,ref int Nationality, ref string ImagePath)
        {
            string Query = @"SELECT [PersonID]
                            ,[NationalNo]
                            ,[FirstName]
                            ,[SecondName]
                            ,[ThirdName]
                            ,[LastName]
                            ,[DateOfBirth]
	                        ,[Gender]
                            ,[Address]
                            ,[Phone]
                            ,[Email]
                            ,[NationalityCountryID]
                            ,[ImagePath]
                            FROM [dbo].[People] where People.PersonID = @PersonID;";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            { 
                 Command.Parameters.AddWithValue("@PersonID", ID);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader()) 
                    {
                        if (Reader.Read())
                        {
                            NationalNo = Reader["NationalNo"] != DBNull.Value ? (string)Reader["NationalNo"] : "";
                            FirstName = Reader["FirstName"] != DBNull.Value ? (string)Reader["FirstName"] : "";
                            SecondName = Reader["SecondName"] != DBNull.Value ? (string)Reader["SecondName"] : "";
                            ThirdName = Reader["ThirdName"] != DBNull.Value ? (string)Reader["ThirdName"] : "";
                            LastName = Reader["LastName"] != DBNull.Value ? (string)Reader["LastName"] : "";
                            DateOfBirth = Reader["DateOfBirth"] != DBNull.Value ? (DateTime)Reader["DateOfBirth"] : DateTime.MinValue;
                            Gender = Reader["Gender"] != DBNull.Value ? (int)Reader["Gender"] : 0;
                            Address = Reader["Address"] != DBNull.Value ? (string)Reader["Address"] : "";
                            Phone = Reader["Phone"] != DBNull.Value ? (string)Reader["Phone"] : "";
                            Email = Reader["Email"] != DBNull.Value ? (string)Reader["Email"] : "";
                            Nationality = Reader["NationalityCountryID"] != DBNull.Value ? (int)Reader["NationalityCountryID"] : -1;
                            ImagePath = Reader["ImagePath"] != DBNull.Value ? (string)Reader["ImagePath"] : "";
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
        public static bool GetPersonInfoByNationalNo(string NationalNo,ref int ID,
           ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
           ref DateTime DateOfBirth, ref int Gender, ref string Address, ref string Email,
           ref string Phone, ref int Nationality, ref string ImagePath)
        {
            string Query = @"SELECT [PersonID]
                            ,[NationalNo]
                            ,[FirstName]
                            ,[SecondName]
                            ,[ThirdName]
                            ,[LastName]
                            ,[DateOfBirth]
	                        ,[Gender]
                            ,[Address]
                            ,[Phone]
                            ,[Email]
                            ,[NationalityCountryID]
                            ,[ImagePath]
                            FROM [dbo].[People] where People.NationalNo = @NationalNo;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@NationalNo", NationalNo);
                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                    
                        if (Reader.Read())
                        {
                            ID = Reader["PersonID"] != DBNull.Value ? (int)Reader["PersonID"] : -1;
                            FirstName = Reader["FirstName"] != DBNull.Value ? (string)Reader["FirstName"] : "";
                            SecondName = Reader["SecondName"] != DBNull.Value ? (string)Reader["SecondName"] : "";
                            ThirdName = Reader["ThirdName"] != DBNull.Value ? (string)Reader["ThirdName"] : "";
                            LastName = Reader["LastName"] != DBNull.Value ? (string)Reader["LastName"] : "";
                            DateOfBirth = Reader["DateOfBirth"] != DBNull.Value ? (DateTime)Reader["DateOfBirth"] : DateTime.MinValue;
                            Gender = Reader["Gender"] != DBNull.Value ? (int)Reader["Gender"] : 0;
                            Address = Reader["Address"] != DBNull.Value ? (string)Reader["Address"] : "";
                            Phone = Reader["Phone"] != DBNull.Value ? (string)Reader["Phone"] : "";
                            Email = Reader["Email"] != DBNull.Value ? (string)Reader["Email"] : "";
                            Nationality = Reader["NationalityCountryID"] != DBNull.Value ? (int)Reader["NationalityCountryID"] : -1;
                            ImagePath = Reader["ImagePath"] != DBNull.Value ? (string)Reader["ImagePath"] : "";

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
   

        public static int AddNewPerson( string NationalNo,
             string FirstName,  string SecondName,  string ThirdName,  string LastName,
             DateTime DateOfBirth,  int Gender,  string Address,  string Email,
             string Phone, int NationalityCountryID,  string ImagePath)
        {

            string Query = @"
            INSERT INTO [dbo].[People]
                        ([NationalNo]
                        ,[FirstName]
                        ,[SecondName]
                        ,[ThirdName]
                        ,[LastName]
                        ,[DateOfBirth]
                        ,[Gender]
                        ,[Address]
                        ,[Phone]
                        ,[Email]
                        ,[NationalityCountryID]
                        ,[ImagePath])
            VALUES
                        (@NationalNo,
                         @FirstName, 
                         @SecondName,
                         @ThirdName, 
                         @LastName, 
                         @DateOfBirth,
                         @Gender,
                         @Address, 
                         @Phone, 
                         @Email, 
                         @NationalityCountryID,
                         @ImagePath);
            SELECT SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@NationalNo", NationalNo );
                Command.Parameters.AddWithValue("@FirstName", FirstName );
                Command.Parameters.AddWithValue("@SecondName", SecondName );
                Command.Parameters.AddWithValue("@ThirdName", (object)ThirdName ?? DBNull.Value);
                Command.Parameters.AddWithValue("@LastName", LastName);
                Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth != DateTime.MinValue ? (object)DateOfBirth : DBNull.Value);
                Command.Parameters.AddWithValue("@Gender",Gender);
                Command.Parameters.AddWithValue("@Address", Address );
                Command.Parameters.AddWithValue("@Phone", Phone );
                Command.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);
                Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                Command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);

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


        public static bool UpdatePerson(int PersonID,string NationalNo,
             string FirstName, string SecondName, string ThirdName, string LastName,
             DateTime DateOfBirth, int Gender, string Address, string Email,
             string Phone, int NationalityCountryID, string ImagePath)
        {
            string Query = @"UPDATE People
                             SET   [NationalNo]  = @NationalNo          
                                  ,[FirstName]   = @FirstName           
                                  ,[SecondName]  = @SecondName          
                                  ,[ThirdName]   = @ThirdName           
                                  ,[LastName]    = @LastName            
                                  ,[DateOfBirth] = @DateOfBirth         
                                  ,[Gender] = @Gender              
                                  ,[Address]  = @Address            
                                  ,[Phone]    = @Phone               
                                  ,[Email]    = @Email              
                                  ,[NationalityCountryID] = @NationalityCountryID
                                  ,[ImagePath] = @ImagePath
                                    WHERE PersonID = @PersonID";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString)) 
            using (SqlCommand Command = new SqlCommand(Query,Connection))
            {
                Command.Parameters.AddWithValue("@PersonID", PersonID);
                Command.Parameters.AddWithValue("@NationalNo", NationalNo);
                Command.Parameters.AddWithValue("@FirstName", FirstName);
                Command.Parameters.AddWithValue("@SecondName", SecondName);
                Command.Parameters.AddWithValue("@ThirdName", (object)ThirdName ?? DBNull.Value);
                Command.Parameters.AddWithValue("@LastName", LastName);
                Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth != DateTime.MinValue ? (object)DateOfBirth : DBNull.Value);
                Command.Parameters.AddWithValue("@Gender", Gender);
                Command.Parameters.AddWithValue("@Address", Address);
                Command.Parameters.AddWithValue("@Phone", Phone);
                Command.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);
                Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                Command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
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


        public static bool DeletePersonByID(int PersonID)
        {
            string Query = @"DELETE FROM People
                            WHERE PersonID = @PersonID";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query,Connection))
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
        public static bool DeletePersonByNationalNo(string NationalNo)
        {
            string Query = @"DELETE FROM People
                            WHERE NationalNo = @NationalNo";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@NationalNo", NationalNo);
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
   

        public static bool IsPersonExist(int PersonID)
        {
            string Query = "select Found=1 from People where PersonID = @PersonID";
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
        public static bool IsPersonExist(string NationalNo)
        {
            string Query = "select Found=1 from People where NationalNo = @NationalNo";
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.AddWithValue("@NationalNo", NationalNo);
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
    
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            string Query = @"SELECT [PersonID]
                                    ,[NationalNo]
                                    ,[FirstName]
                                    ,[SecondName]
                                    ,[ThirdName]
                                    ,[LastName]
                                    ,[DateOfBirth]
	                                ,Gender =
	                                    CASE
	                                     	WHEN Gender=0 THEN 'Male'
   	                                        WHEN Gender=1 THEN 'Female'
   	                                    ELSE 'Unknown'
                                    END
                                    ,[Address]
                                    ,[Phone]
                                    ,[Email]
                                    ,C.CountryName     
                            FROM [dbo].[People] inner join Countries C on People.NationalityCountryID = C.CountryID 
                            order by PersonID";
            using(SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            using (SqlCommand Command = new SqlCommand(Query,Connection))
            {
                try
                {
                    Connection.Open();
                    using(SqlDataReader Reader = Command.ExecuteReader())
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
