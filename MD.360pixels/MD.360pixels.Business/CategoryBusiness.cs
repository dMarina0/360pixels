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
            return BusinessContext.Current.repositoryContext.categoryRepository.ReadAll();
        }
        public void Insert(Category category)
        {
            BusinessContext.Current.repositoryContext.categoryRepository.Insert(category);
        }
        public void Delete(Guid categoryID)
        {
            BusinessContext.Current.repositoryContext.categoryRepository.Delete(categoryID);
        }
        public void Update(Category category)
        {
            BusinessContext.Current.repositoryContext.categoryRepository.Update(category);
        }
        public Category ReadById(Guid categoryID)
        {
            return BusinessContext.Current.repositoryContext.categoryRepository.ReadById(categoryID);
        }
    }
}
