using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Business
{
    public class UserChallengesBusiness
    {
        public List<UserChallenge> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.UserChallengesRepository.ReadAll();
        }
        public void Insert(UserChallenge userChallenge)
        {
            BusinessContext.Current.RepositoryContext.UserChallengesRepository.Insert(userChallenge);
        }
        public void Delete(Guid UserID, Guid ChallengeID)
        {
            BusinessContext.Current.RepositoryContext.UserChallengesRepository.Delete(UserID,ChallengeID);
        }
    }
}
