﻿using MD._360Pixels.Model;
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
        void Insert(Blog Blog);
         void Delete(Guid BlogID);
        void Update(Blog Blog);
        Blog ReadById(Guid BlogID);

    }
}
