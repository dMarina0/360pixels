using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360pixels.Model
{
    public class UserChallenge
    {
        public Guid UserID { get; set; }

        public Guid ChallengeID { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual Challenge Challenge { get; set; }
    }
}
