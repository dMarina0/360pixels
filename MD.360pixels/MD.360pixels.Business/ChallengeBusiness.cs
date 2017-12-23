using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Business
{
   public class ChallengeBusiness
    {
        public List<Challenge> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ChallengeRepository.ReadAll();
        }
        public void Insert(Challenge Challenge)
        {
            BusinessContext.Current.RepositoryContext.ChallengeRepository.Insert(Challenge);
        }
        public void Delete(Guid ChallengeID)
        {
            BusinessContext.Current.RepositoryContext.ChallengeRepository.Delete(ChallengeID);
        }
        public void Update(Challenge Challenge)
        {
            BusinessContext.Current.RepositoryContext.ChallengeRepository.Update(Challenge);
        }
        public Challenge ReadById(Guid ChallengeID)
        {
            return BusinessContext.Current.RepositoryContext.ChallengeRepository.ReadById(ChallengeID);
        }
    }
}
