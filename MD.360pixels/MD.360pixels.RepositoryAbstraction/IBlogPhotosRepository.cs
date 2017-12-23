using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryAbstraction
{
    public interface IBlogPhotosRepository
    {
        List<BlogPhoto> ReadAll();
        void Insert(BlogPhoto BlogPhoto);
        void Delete(Guid BlogID, Guid PhotoID);
    }
}
