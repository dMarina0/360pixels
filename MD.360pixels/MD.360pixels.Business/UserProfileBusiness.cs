using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Business
{
   public class UserProfileBusiness
    {
        public List<UserProfile> ReadAll()
        {
            return BusinessContext.Current.repositoryContext.userProfileRepository.ReadAll();
        }
        public void Insert(UserProfile user)
        {
            BusinessContext.Current.repositoryContext.userProfileRepository.Insert(user);
        }
        public void Delete(Guid userID)
        {
            BusinessContext.Current.repositoryContext.userProfileRepository.Delete(userID);
        }
        public void Update(UserProfile user)
        {
            BusinessContext.Current.repositoryContext.userProfileRepository.Update(user);
        }
        public UserProfile ReadById(Guid userID)
        {
            return BusinessContext.Current.repositoryContext.userProfileRepository.ReadById(userID);
        }
    }
}
