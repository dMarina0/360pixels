using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryAbstraction
{
    public interface ICategoryRepository
    {
        List<Category> ReadAll();
        void Insert(Category Category);
        void Delete(Guid CategoryID);
        void Update(Category Category);
        Category ReadById(Guid CategoryID);
    }
}
