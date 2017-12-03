using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360Pixels.Model
{
    public class Photos
    {
        public Guid PhotoID { get; set; }

        public string Photo { get; set; }

        public int Likes { get; set; }

        public string Location { get; set; }

        public string Comment { get; set; }
    }
}
