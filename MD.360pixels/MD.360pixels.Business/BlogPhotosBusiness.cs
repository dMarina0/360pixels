using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Business
{
    public class BlogPhotosBusiness
    {
        public List<BlogPhoto> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.BlogPhotosRepository.ReadAll();
        }
        public void Insert(BlogPhoto BlogPhoto)
        {
            BusinessContext.Current.RepositoryContext.BlogPhotosRepository.Insert(BlogPhoto);
        }
        public void Delete(Guid BlogID, Guid PhotoID)
        {
            BusinessContext.Current.RepositoryContext.BlogPhotosRepository.Delete(BlogID, PhotoID);
        }
    }
}
