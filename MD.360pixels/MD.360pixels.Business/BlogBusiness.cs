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
            return BusinessContext.Current.repositoryContext.blogRepository.ReadAll();
        }
        public void Insert(Blog blog)
        {
            BusinessContext.Current.repositoryContext.blogRepository.Insert(blog);
        }
        public void Delete(Guid blogID)
        {
            BusinessContext.Current.repositoryContext.blogRepository.Delete(blogID);
        }
        public void Update(Blog blog)
        {
            BusinessContext.Current.repositoryContext.blogRepository.Update(blog);
        }
        public Blog ReadById(Guid blogID)
        {
            return BusinessContext.Current.repositoryContext.blogRepository.ReadById(blogID);
        }
    }
}
