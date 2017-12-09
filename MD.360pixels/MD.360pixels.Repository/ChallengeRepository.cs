using MD._360pixels.Repository.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Repository
{
    public class ChallengeRepository:BaseRepository<Challenge>
    {
        #region ReadAll

        public List<Challenge> ReadAll()
        {
            return ReadAll("Challenges_ReadAll");
        
        }

        protected override Challenge GetModelfromReader(SqlDataReader reader)
        {
            Challenge challenge = new Challenge();
            challenge.ChallengeID = reader.GetGuid(reader.GetOrdinal("ChallengeID"));
            challenge.ChallengeName = reader.GetString(reader.GetOrdinal("ChallengeName"));
            challenge.Description = reader.GetString(reader.GetOrdinal("Description"));
            return challenge;
        }
        #endregion


        #region Insert

        public void Insert(Challenge challenge)
        {
            Insert("Challenges_Create", AddParameter(challenge));
                   
            
        }
        protected override SqlParameter[] AddParameter(Challenge challenge)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("ChallengeID", challenge.ChallengeID),
                new SqlParameter("ChallengeName", challenge.ChallengeName),
                new SqlParameter("Description", challenge.Description)

            };


            return parameter;
        }

        #endregion

        public void Delete(Guid challengeID)
        {
            Delete("Challenges_Delete", SetID(challengeID));
              

        }
        protected override SqlParameter[] SetID(Guid challengeID)
        {
            

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("ChallengeID", challengeID)
            };


            return parameter;



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

        public Challenge ReadById(Guid challengeID)
        {
            return ReadByID("Categories_ReadById", SetID(challengeID)).First();

        }

       
    }
}

