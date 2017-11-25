using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360pixels.Model
{
    public class Category
    {
        public Guid CategoryID { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<CategoryPhoto> Photos { get; set; }
    }
}
