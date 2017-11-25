using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360pixels.Model
{
    public class Challenge
    {
        public Guid ChallengeID { get; set; }

        public string ChallengeName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ChallengePhoto> Photos { get; set; }

        public virtual ICollection<UserChallenge> UserChallenges { get; set; }

    }
}
