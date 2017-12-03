﻿using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Repository
{
    public class ChallengeRepository
    {
        public List<Challenge> ReadAll()
        {
            List<Challenge> challenges = new List<Challenge>();

            string connectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "Challenges_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Challenge challenge = new Challenge();
                                challenge.ChallengeID = reader.GetGuid(reader.GetOrdinal("ChallengeID"));
                                challenge.ChallengeName = reader.GetString(reader.GetOrdinal("ChallengeName"));
                                challenge.Description = reader.GetString(reader.GetOrdinal("Description"));
                                

                                challenges.Add(challenge);
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

            return challenges;
        }

        public void Insert(Challenge challenge)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Challenges_Create";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("ChallengeID", challenge.ChallengeID));
                    command.Parameters.Add(new SqlParameter("ChallengeName", challenge.ChallengeName));
                    command.Parameters.Add(new SqlParameter("Description", challenge.Description));
                    

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

        public void Delete(Challenge challenge)
        {
            string StringConnection = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Challenges_Delete";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("ChallengeID", challenge.ChallengeID));
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

        public void Update(Challenge challenge)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Challenges_Update";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("ChallengeID", challenge.ChallengeID));
                    command.Parameters.Add(new SqlParameter("ChallengeName", challenge.ChallengeName));
                    command.Parameters.Add(new SqlParameter("Description", challenge.Description));
                   


                    connection.Open();
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
        }

        public Challenge ReadById(Challenge challenge)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Challenges_ReadById";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("ChallengeID", challenge.ChallengeID));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                           
                            challenge.ChallengeName = reader.GetString(reader.GetOrdinal("ChallengeName"));
                            challenge.Description = reader.GetString(reader.GetOrdinal("Description"));
                            
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
            return challenge;
        }
    }
}
