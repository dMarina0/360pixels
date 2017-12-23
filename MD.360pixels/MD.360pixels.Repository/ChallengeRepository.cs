using MD._360pixels.Repository.Core;
using MD._360pixels.RepositoryAbstraction;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Repository
{
    public class ChallengeRepository:BaseRepository<Challenge>,IChallengeRepository
    {

        public List<Challenge> ReadAll()
        {
            return ReadAll("Challenges_ReadAll");
        
        }

        
        public void Insert(Challenge challenge)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("ChallengeID", challenge.ChallengeID),
                new SqlParameter("ChallengeName", challenge.ChallengeName),
                new SqlParameter("Description", challenge.Description)

            };
            Insert("Challenges_Create", parameter);
                   
        }

        public void Delete(Guid challengeID)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                     new SqlParameter("ChallengeID", challengeID)
            };
          
            Delete("Challenges_Delete", parameter);
        }
        

        public void Update(Challenge challenge)
        {
            SqlParameter[] parameter = new SqlParameter[]
           {
                new SqlParameter("ChallengeID", challenge.ChallengeID),
                new SqlParameter("ChallengeName", challenge.ChallengeName),
                new SqlParameter("Description", challenge.Description)

           };

            Update("Challenges_Update", parameter);
            
        }

        public Challenge ReadById(Guid challengeID)
        {
            SqlParameter parameter = new SqlParameter("ChallengeID", challengeID);
           
            return ReadByID("Challenges_ReadById", parameter);

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

