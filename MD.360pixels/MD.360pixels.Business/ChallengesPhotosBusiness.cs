using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Business
{

    public class ChallengesPhotosBusiness
    {
        public List<ChallengePhoto> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ChallengesPhotosRepository.ReadAll();
        }
        public void Insert(ChallengePhoto ChallengePhoto)
        {
            BusinessContext.Current.RepositoryContext.ChallengesPhotosRepository.Insert(ChallengePhoto);
        }
        public void Delete(Guid ChallengeID, Guid PhotoID)
        {
            BusinessContext.Current.RepositoryContext.ChallengesPhotosRepository.Delete(ChallengeID, PhotoID);
        }
    }
}
