using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Business
{
    public class CategoryBusiness
    {
        public List<Category> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.CategoryRepository.ReadAll();
        }
        public void Insert(Category Category)
        {
            BusinessContext.Current.RepositoryContext.CategoryRepository.Insert(Category);
        }
        public void Delete(Guid CategoryID)
        {
            BusinessContext.Current.RepositoryContext.CategoryRepository.Delete(CategoryID);
        }
        public void Update(Category Category)
        {
            BusinessContext.Current.RepositoryContext.CategoryRepository.Update(Category);
        }
        public Category ReadById(Guid CategoryID)
        {
            return BusinessContext.Current.RepositoryContext.CategoryRepository.ReadById(CategoryID);
        }
    }
}
