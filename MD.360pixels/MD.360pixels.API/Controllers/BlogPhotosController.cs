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
    [RoutePrefix("api/blogphotos")]
    public class BlogPhotosController: ApiController
    {
        //GET api/blogphotos
        [HttpGet]
        [Route("")]
        public IEnumerable<BlogPhoto> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.BlogPhotosBusiness.ReadAll();
            }
        }

        //POST api/blogphotos
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] BlogPhoto photos)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.BlogPhotosBusiness.Insert(photos);
            }
        }
        //DELETE api/blog/{Guid}/{Guid}
        [HttpDelete]
        [Route("{blogId:Guid}/{photoId:Guid}")]
        public void Delete(Guid blogId ,Guid photoID)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.BlogPhotosBusiness.Delete(blogId,photoID);
            }
        }
       
    }
}