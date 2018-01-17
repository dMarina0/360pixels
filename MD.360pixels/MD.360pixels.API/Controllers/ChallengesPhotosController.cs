using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MD._360pixels.API.Controllers
{
    [RoutePrefix("api/challengesphotos")]
    public class ChallengesPhotosController: ApiController
    {
        //GET api/challengesphotos
        [HttpGet]
        [Route("")]
        public IEnumerable<ChallengePhoto> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.ChallengePhotosBusiness.ReadAll();
            }
        }

        //POST api/challengesphotos
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] ChallengePhoto photos)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ChallengePhotosBusiness.Insert(photos);
            }
        }
        //DELETE api/challengesphotos/{Guid}/{Guid}
        [HttpDelete]
        [Route("{challengeId:Guid}/{photoId:Guid}")]
        public void Delete(Guid challengeId, Guid photoID)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.BlogPhotosBusiness.Delete(challengeId, photoID);
            }
        }

    }
}