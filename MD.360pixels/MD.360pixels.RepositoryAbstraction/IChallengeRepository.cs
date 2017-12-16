using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryAbstraction
{
  public  interface IChallengeRepository
    {
        List<Challenge> ReadAll();
        void Insert(Challenge challenge);
        void Delete(Guid challengeID);
        void Update(Challenge challenge);
        Challenge ReadById(Guid challengeID);
    }
}
