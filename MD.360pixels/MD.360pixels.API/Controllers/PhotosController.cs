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
    [RoutePrefix("api/photos")]
    public class PhotosController : ApiController
    {
        //GET api/photos
        [HttpGet]
        [Route("")]
        public IEnumerable<Photos> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.PhotoBusiness.ReadAll();
            }
        }
        //GET api/photos/{Guid}
        [HttpGet]
        [Route("{photosId:Guid}")]
        public Photos ReadById(Guid photoId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.PhotoBusiness.ReadById(photoId);
            }
        }
        //POST api/photos
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] Photos photo)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.PhotoBusiness.Insert(photo);
            }
        }
        //DELETE api/photos/{Guid}
        [HttpDelete]
        [Route("{photoId:Guid}")]
        public void Delete(Guid photoId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.PhotoBusiness.Delete(photoId);
            }
        }
        //PUT api/photos
        [HttpPut]
        [Route("")]
        public void Update(Photos photo)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.PhotoBusiness.Update(photo);
            }
        }
    }
}