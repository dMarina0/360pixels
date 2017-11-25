using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360pixels.Model
{
    public class CategoryPhoto
    {
        public Guid CategoryID { get; set; }

        public Guid PhotoID { get; set; }

        public virtual Category Category { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
