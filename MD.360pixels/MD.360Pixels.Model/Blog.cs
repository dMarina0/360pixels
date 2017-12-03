using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360Pixels.Model
{
    public class Blog
    {
       
        public Guid BlogID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }
    
    }
}
