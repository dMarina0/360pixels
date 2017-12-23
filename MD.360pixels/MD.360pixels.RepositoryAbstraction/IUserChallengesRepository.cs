using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryAbstraction
{
    public interface IUserChallengesRepository
    {
        List<UserChallenge> ReadAll();
        void Insert(UserChallenge UserChallenge);
        void Delete(Guid UserID, Guid ChallengeID);
    }
}
