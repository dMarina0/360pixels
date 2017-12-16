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
            return BusinessContext.Current.repositoryContext.challengeRepository.ReadAll();
        }
        public void Insert(Challenge challenge)
        {
            BusinessContext.Current.repositoryContext.challengeRepository.Insert(challenge);
        }
        public void Delete(Guid challengeID)
        {
            BusinessContext.Current.repositoryContext.challengeRepository.Delete(challengeID);
        }
        public void Update(Challenge challenge)
        {
            BusinessContext.Current.repositoryContext.challengeRepository.Update(challenge);
        }
        public Challenge ReadById(Guid challengeID)
        {
            return BusinessContext.Current.repositoryContext.challengeRepository.ReadById(challengeID);
        }
    }
}
