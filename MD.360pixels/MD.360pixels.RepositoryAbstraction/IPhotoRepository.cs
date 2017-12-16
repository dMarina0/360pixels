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
        void Insert(Photos photos);
        void Delete(Guid photoID);
        void Update(Photos photo);
        Photos ReadById(Guid photoID);
    }
}
