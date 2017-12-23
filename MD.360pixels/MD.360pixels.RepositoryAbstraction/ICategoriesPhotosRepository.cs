using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryAbstraction
{
    public interface ICategoriesPhotosRepository
    {
        List<CategoryPhoto> ReadAll();
        void Insert(CategoryPhoto CategoryPhoto);
        void Delete(Guid CategoryID, Guid PhotoID);
    }
}
