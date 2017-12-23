using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Business
{
    public class PhotoBusiness
    {
        public List<Photos> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.PhotoRepository.ReadAll();
        }
        public void Insert(Photos Photo)
        {
            BusinessContext.Current.RepositoryContext.PhotoRepository.Insert(Photo);
        }
        public void Delete(Guid PhotoID)
        {
            BusinessContext.Current.RepositoryContext.PhotoRepository.Delete(PhotoID);
        }
        public void Update(Photos Photo)
        {
            BusinessContext.Current.RepositoryContext.PhotoRepository.Update(Photo);
        }
        public Photos ReadById(Guid PhotoID)
        {
            return BusinessContext.Current.RepositoryContext.PhotoRepository.ReadById(PhotoID);
        }
    }
}
