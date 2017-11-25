using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360pixels.Model
{
    public class Blog
    {
        public Guid BlogID { get; set; }

        public string Title { get; set; }

        public string Autor { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public virtual ICollection<BlogPhoto> Photos { get; set; }

    }
}
