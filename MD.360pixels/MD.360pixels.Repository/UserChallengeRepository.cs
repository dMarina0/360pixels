using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Repository
{
   public  class UserChallengeRepository
    {

        public List<UserChallenge> ReadAll()
        {
            List<UserChallenge> userchallenges = new List<UserChallenge>();

            string connectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "UserChallenges_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserChallenge userchallenge = new UserChallenge();
                                userchallenge.ChallengeID = reader.GetGuid(reader.GetOrdinal("ChallengeID"));
                                userchallenge.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
                                

                                userchallenges.Add(userchallenge);
                            }
                        }

                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Exception : {0}", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }

            return userchallenges;
        }

        public void Insert(UserChallenge userChallenge)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "UserChallenges_Create";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("ChallengeID", userChallenge.ChallengeID));
                    command.Parameters.Add(new SqlParameter("UserID", userChallenge.UserID));
                   


                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException Ex)
                {
                    Console.WriteLine("Exception : {0}", Ex.ToString());
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void Delete(UserChallenge userChallenge)
        {
            string StringConnection = "Server =DESKTOP-2HQ1GA6 ; Database =test; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "UserChallenges_Delete";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("ChallengeID", userChallenge.ChallengeID));
                    command.Parameters.Add(new SqlParameter("UserID", userChallenge.UserID));
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Exception: {0} ", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
