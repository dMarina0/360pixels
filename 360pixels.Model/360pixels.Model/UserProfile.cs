using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360pixels.Model
{
    public class UserProfile
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<UserProfilePhoto> Photos { get; set; }

        public virtual ICollection<UserChallenge> Challenges { get; set; }
    }
}
