using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360pixels.Model
{
    public class UserProfilePhoto
    {
        public Guid UserID { get; set; }

        public Guid PhotoID { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual Photo Photos { get; set; }
    }
}
