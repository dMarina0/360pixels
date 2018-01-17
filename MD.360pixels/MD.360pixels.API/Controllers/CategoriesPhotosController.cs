using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MD._360pixels.API.Controllers
{
    [RoutePrefix("api/categoriesphotos")]
    public class CategoriesPhotosController : ApiController
    {
        //GET api/categoriesphotos
        [HttpGet]
        [Route("")]
        public IEnumerable<CategoryPhoto> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.CategoriesPhotosBusiness.ReadAll();
            }
        }

        //POST api/categoriesphotos
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] CategoryPhoto photo)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.CategoriesPhotosBusiness.Insert(photo);
            }
        }
        //DELETE api/categoriesphotos/{Guid}/{Guid}
        [HttpDelete]
        [Route("{categoryId:Guid}/{photoId:Guid}")]
        public void Delete(Guid categoryId, Guid photoID)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.CategoriesPhotosBusiness.Delete(categoryId, photoID);
            }
        }

    }
}