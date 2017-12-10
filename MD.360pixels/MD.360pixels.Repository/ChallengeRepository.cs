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

        public List<Challenge> ReadAll()
        {
            return ReadAll("Challenges_ReadAll");
        
        }

        
        public void Insert(Challenge challenge)
        {
            Insert("Challenges_Create", AddParameter(challenge));
                   
            
        }

        public void Delete(Guid challengeID)
        {
            Delete("Challenges_Delete", SetID(challengeID));
              

        }
        

        public void Update(Challenge challenge)
        {

            Update("Challenges_Update", AddParameter(challenge));
            
        }

        public Challenge ReadById(Guid challengeID)
        {
            return ReadByID("Challenges_ReadById", SetID(challengeID)).FirstOrDefault();

        }

        protected override SqlParameter[] SetID(Guid challengeID)
        {


            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("ChallengeID", challengeID)
            };


            return parameter;

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
        protected override Challenge GetModelfromReader(SqlDataReader reader)
        {
            Challenge challenge = new Challenge();
            challenge.ChallengeID = reader.GetGuid(reader.GetOrdinal("ChallengeID"));
            challenge.ChallengeName = reader.GetString(reader.GetOrdinal("ChallengeName"));
            challenge.Description = reader.GetString(reader.GetOrdinal("Description"));
            return challenge;
        }

    }
}

