using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryAbstraction
{
    public interface IPhotoRepository
    {
        List<Photos> ReadAll();
        void Insert(Photos Photos);
        void Delete(Guid PhotoID);
        void Update(Photos Photo);
        Photos ReadById(Guid PhotoID);
    }
}
