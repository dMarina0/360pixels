using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MD._360pixels.Repository
{
    public class UserProfileRepository
    {
        #region Methods

    
        public List<UserProfile> ReadAll()
        {
            List<UserProfile> users = new List<UserProfile>();
            string connectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "UserProfile_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                UserProfile user = new UserProfile();
                                user.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
                                user.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                                user.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                user.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                                user.BirthDay = reader.GetDateTime(reader.GetOrdinal("BirthDay"));
                                user.Camera= reader.GetString(reader.GetOrdinal("Camera"));
                                user.Country = reader.GetString(reader.GetOrdinal("Country"));
                                user.Camera = reader.GetString(reader.GetOrdinal("Camera"));
                                user.Website = reader.GetString(reader.GetOrdinal("Website"));

                                users.Add(user);



                            }
                        }
                    }
                }
                catch(SqlException ex)
                {
                    Console.WriteLine("Exception : {0}", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
                return users;
        }

        public void Insert(UserProfile user)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "UserProfile_Create";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                   
                    command.Parameters.Add(new SqlParameter("UserID", user.UserID));
                    command.Parameters.Add(new SqlParameter("UserName", user.UserName));
                    command.Parameters.Add(new SqlParameter("FirstName", user.FirstName));
                    command.Parameters.Add(new SqlParameter("LastName", user.LastName));
                    command.Parameters.Add(new SqlParameter("BirthDay", user.BirthDay));
                    command.Parameters.Add(new SqlParameter("Camera", user.Camera));
                    command.Parameters.Add(new SqlParameter("Country", user.Country));
                    command.Parameters.Add(new SqlParameter("Website", user.Website));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(SqlException Ex)
                {
                    Console.WriteLine("Exception : {0}", Ex.ToString());
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void Delete(UserProfile user)
        {
            string StringConnection= "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "UserProfile_Delete";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("UserID", user.UserID));
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch(SqlException ex)
                {
                    Console.WriteLine("Exception: {0} ", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public void Update(UserProfile user)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "UserProfile_Update";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("UserID", user.UserID));
                    command.Parameters.Add(new SqlParameter("UserName", user.UserName));
                    command.Parameters.Add(new SqlParameter("FirstName", user.FirstName));
                    command.Parameters.Add(new SqlParameter("LastName", user.LastName));
                    command.Parameters.Add(new SqlParameter("BirthDay", user.BirthDay));
                    command.Parameters.Add(new SqlParameter("Camera", user.Camera));
                    command.Parameters.Add(new SqlParameter("Country", user.Country));
                    command.Parameters.Add(new SqlParameter("Website", user.Website));

                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch(SqlException ex)
                {
                    Console.WriteLine("Exception : {0} ", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public UserProfile ReadById(UserProfile user)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "UserProfie_ReadById";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("UserID", user.UserID));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           
                            user.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                            user.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                            user.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                            user.BirthDay = reader.GetDateTime(reader.GetOrdinal("BirthDay"));
                            user.Camera = reader.GetString(reader.GetOrdinal("Camera"));
                            user.Country = reader.GetString(reader.GetOrdinal("Country"));
                            user.Camera = reader.GetString(reader.GetOrdinal("Camera"));
                            user.Website = reader.GetString(reader.GetOrdinal("Website"));
                        }
                    }
                    
                    command.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Exception : {0} ", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return user;
        }


 

        #endregion
    }
}
