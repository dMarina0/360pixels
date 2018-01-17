using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MD._360pixels.API.Controllers
{
    [RoutePrefix("api/blog")]
    public class BlogController: ApiController
    {
        //GET api/blog
        [HttpGet]
        [Route("")]
        public IEnumerable<Blog> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.BlogBusiness.ReadAll();
            }
        }
        //GET api/blog/{Guid}
        [HttpGet]
        [Route("{blogId:Guid}")]
        public Blog ReadById(Guid blogId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.BlogBusiness.ReadById(blogId);
            }
        }
        //POST api/blog
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] Blog blog)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.BlogBusiness.Insert(blog);
            }
        }
        //DELETE api/blog/{Guid}
        [HttpDelete]
        [Route("{blogId:Guid}")]
        public void Delete(Guid blogId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.BlogBusiness.Delete(blogId);
            }
        }
        //PUT api/blog
        [HttpPut]
        [Route("")]
        public void Update(Blog blog)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.BlogBusiness.Update(blog);
            }
        }
    }
}