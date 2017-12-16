using MD._360pixels.Repository.Core;
using MD._360pixels.RepositoryAbstraction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryFactory
{
    public class Getter
    {
        public static IRepositoryContext Instance()
        {
            bool test = true;
            if(test)
            {
               return  new RepositoryContext();
            }
            return default(IRepositoryContext);
        }
            

    }
}
