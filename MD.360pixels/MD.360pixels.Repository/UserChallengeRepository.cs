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
    public class UserChallengeRepository : BaseRepository<UserChallenge> , IUserChallengesRepository
    {
        public void Insert(UserChallenge userChallenge)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("UserID",userChallenge.UserID),
                new SqlParameter("ChallengeID", userChallenge.ChallengeID)
            };

            Insert("UserChallenges_Create", parameter);
        }

        public void Delete(Guid UserID, Guid ChallengeID)
        {
            SqlParameter[] parameter = new SqlParameter[]
           {
                new SqlParameter("UserID", UserID),
                new SqlParameter("ChallengeID",ChallengeID)
           };

            Delete("UserChallenges_Delete", parameter);
        }

        public List<UserChallenge> ReadAll()
        {
            return ReadAll("UserChallenges_ReadAll");
        }

        protected override UserChallenge GetModelfromReader(SqlDataReader reader)
        {
            UserChallenge UserChallenge = new UserChallenge();
            UserChallenge.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            UserChallenge.ChallengeID = reader.GetGuid(reader.GetOrdinal("ChallengeID"));
            
            return UserChallenge;
        }
    }
}
