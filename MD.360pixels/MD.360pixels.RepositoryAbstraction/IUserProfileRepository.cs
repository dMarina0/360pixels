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
        void Insert(UserProfile User);
        void Delete(Guid UserID);
        void Update(UserProfile User);
        UserProfile ReadById(Guid UserID);
    }
}
