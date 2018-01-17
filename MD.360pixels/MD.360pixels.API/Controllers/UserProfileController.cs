using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MD._360pixels.API.Controllers
{
    [RoutePrefix("api/userprofile")]
    public class UserProfileController: ApiController
    {
        //GET api/userprofile
        [HttpGet]
        [Route("")]
        public IEnumerable<UserProfile> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.UserProfileBusiness.ReadAll();
            }
        }
        //GET api/userprofile/{Guid}
        [HttpGet]
        [Route("{userId:Guid}")]
        public UserProfile ReadById(Guid userId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.UserProfileBusiness.ReadById(userId);
            }
        }
        //POST api/userprofile
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] UserProfile user)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.UserProfileBusiness.Insert(user);
            }
        }

        //DELETE api/userprofile/{Guid}
        [HttpDelete]
        [Route("{userId:Guid}")]
        public void Delete(Guid userId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.UserProfileBusiness.Delete(userId);
            }
        }
        //PUT api/userprofile
        [HttpPut]
        [Route("")]
        public void Update(UserProfile user)
        {
            using(BusinessContext context = new BusinessContext())
            {
                context.UserProfileBusiness.Update(user);
            }
        }
    }
}