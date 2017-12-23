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
            return BusinessContext.Current.RepositoryContext.UserProfileRepository.ReadAll();
        }
        public void Insert(UserProfile User)
        {
            BusinessContext.Current.RepositoryContext.UserProfileRepository.Insert(User);
        }
        public void Delete(Guid UserID)
        {
            BusinessContext.Current.RepositoryContext.UserProfileRepository.Delete(UserID);
        }
        public void Update(UserProfile User)
        {
            BusinessContext.Current.RepositoryContext.UserProfileRepository.Update(User);
        }
        public UserProfile ReadById(Guid UserID)
        {
            return BusinessContext.Current.RepositoryContext.UserProfileRepository.ReadById(UserID);
        }
    }
}
