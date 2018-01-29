using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MD._360pixels.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/userchallenges")]
    public class UserChallengesController : ApiController
    {
        //GET api/userchallenges
        [HttpGet]
        [Route("")]
        public IEnumerable<UserChallenge> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.UserChallengesBusiness.ReadAll();
            }
        }

        //POST api/userchallenges
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] UserChallenge userChallenge)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.UserChallengesBusiness.Insert(userChallenge);
            }
        }
        //DELETE api/userchallenges/{Guid}/{Guid]
        [HttpDelete]
        [Route("{userId:Guid}/{challengeId:Guid}")]
        public void Delete(Guid userId, Guid challengeId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.UserChallengesBusiness.Delete(userId, challengeId);
            }
        }

    }
}