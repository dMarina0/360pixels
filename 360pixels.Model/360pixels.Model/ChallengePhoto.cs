using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360pixels.Model
{
    public class ChallengePhoto
    {
        public Guid ChallengeID { get; set; }

        public Guid PhotoID { get; set; }

        public virtual Challenge Challenge{ get; set; }

        public virtual Photo Photo { get; set; }
    }
}
