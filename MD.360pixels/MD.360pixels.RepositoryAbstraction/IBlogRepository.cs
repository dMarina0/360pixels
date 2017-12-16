using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryAbstraction
{
    public interface IBlogRepository
    {
        List<Blog> ReadAll();
        void Insert(Blog blog);
         void Delete(Guid blogID);
        void Update(Blog blog);
        Blog ReadById(Guid blogID);

    }
}
