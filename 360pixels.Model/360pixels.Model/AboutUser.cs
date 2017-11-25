using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360pixels.Model
{
    public class AboutUser
    {
        public Guid AboutUserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public string Country { get; set; }

        public string Website { get; set; }

        public UserProfile UserProfile { get; set; }

    }
}
