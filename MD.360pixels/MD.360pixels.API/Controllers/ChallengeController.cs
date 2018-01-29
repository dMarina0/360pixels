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
    [RoutePrefix("api/challenges")]
    public class ChallengeController : ApiController
    {
        //GET api/challenges
        [HttpGet]
        [Route("")]
        public IEnumerable<Challenge> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.ChallengeBusiness.ReadAll();
            }
        }
        //GET api/challenges/{Guid}
        [HttpGet]
        [Route("{challengeId:Guid}")]
        public Challenge ReadById(Guid challengeId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.ChallengeBusiness.ReadById(challengeId);
            }
        }
        //POST api/challenges
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] Challenge challenge)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ChallengeBusiness.Insert(challenge);
            }
        }
        //DELETE api/challenges/{Guid}
        [HttpDelete]
        [Route("{challengeId:Guid}")]
        public void Delete(Guid challengeId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ChallengeBusiness.Delete(challengeId);
            }
        }
        //PUT api/challenges
        [HttpPut]
        [Route("")]
        public void Update(Challenge challenge)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ChallengeBusiness.Update(challenge);
            }
        }
    }
}