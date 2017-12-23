using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Business
{
    public class CategoriesPhotosBusiness
    {
        public List<CategoryPhoto> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.CategoriesPhotosRepository.ReadAll();
        }
        public void Insert(CategoryPhoto CategoryPhoto)
        {
            BusinessContext.Current.RepositoryContext.CategoriesPhotosRepository.Insert(CategoryPhoto);
        }
        public void Delete(Guid CategoryID, Guid PhotoID)
        {
            BusinessContext.Current.RepositoryContext.CategoriesPhotosRepository.Delete(CategoryID, PhotoID);
        }
    }
}
