using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryAbstraction
{
    public interface IUserProfileRepository
    {
        List<UserProfile> ReadAll();
        void Insert(UserProfile user);
        void Delete(Guid userID);
        void Update(UserProfile user);
        UserProfile ReadById(Guid userID);
    }
}
