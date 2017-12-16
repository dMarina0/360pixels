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
            return BusinessContext.Current.repositoryContext.photoRepository.ReadAll();
        }
        public void Insert(Photos photo)
        {
            BusinessContext.Current.repositoryContext.photoRepository.Insert(photo);
        }
        public void Delete(Guid photoID)
        {
            BusinessContext.Current.repositoryContext.photoRepository.Delete(photoID);
        }
        public void Update(Photos photo)
        {
            BusinessContext.Current.repositoryContext.photoRepository.Update(photo);
        }
        public Photos ReadById(Guid photoID)
        {
            return BusinessContext.Current.repositoryContext.photoRepository.ReadById(photoID);
        }
    }
}
