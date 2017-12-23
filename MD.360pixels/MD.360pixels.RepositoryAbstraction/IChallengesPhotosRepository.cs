using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryAbstraction
{
    public interface IChallengesPhotosRepository
    {
        List<ChallengePhoto> ReadAll();
        void Insert(ChallengePhoto ChallengePhoto);
        void Delete(Guid ChallengeID, Guid PhotoID);
    }
}
