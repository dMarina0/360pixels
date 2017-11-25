using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360pixels.Model
{
    public class BlogPhoto
    {
        public Guid BlogID { get; set; }

        public Guid PhotoID { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
