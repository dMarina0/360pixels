using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Business
{
    public class BlogBusiness
    {
       public  List<Blog> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.BlogRepository.ReadAll();
        }
        public void Insert(Blog Blog)
        {
            BusinessContext.Current.RepositoryContext.BlogRepository.Insert(Blog);
        }
        public void Delete(Guid BlogID)
        {
            BusinessContext.Current.RepositoryContext.BlogRepository.Delete(BlogID);
        }
        public void Update(Blog Blog)
        {
            BusinessContext.Current.RepositoryContext.BlogRepository.Update(Blog);
        }
        public Blog ReadById(Guid BlogID)
        {
            return BusinessContext.Current.RepositoryContext.BlogRepository.ReadById(BlogID);
        }
    }
}
