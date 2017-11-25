using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360pixels.Model
{
    public class Photo
    {
        public Guid PhotoID { get; set; }

        public string Photos { get; set; }

        public int Likes { get; set; }

        public string Location { get; set; }

        public string Comments { get; set; }

        public virtual ICollection<UserProfilePhoto> UserProfilePhotos { get; set; }

        public virtual ICollection<BlogPhoto> BlogPhotos { get; set; }

        public virtual ICollection<CategoryPhoto> CategoryPhotos { get; set; }

        public virtual ICollection<ChallengePhoto> ChallengePhotos { get; set; }
    }
}
