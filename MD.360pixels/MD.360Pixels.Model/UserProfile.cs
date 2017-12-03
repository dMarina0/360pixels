using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MD._360Pixels.Model
{
    public class UserProfile
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public string Camera { get; set; }

        public string Country { get; set; }

        public string Website { get; set; }

        
    }

}
