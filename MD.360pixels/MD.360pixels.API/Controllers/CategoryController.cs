using MD._360pixels.Business.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MD._360pixels.API.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        //GET api/category
        [HttpGet]
        [Route("")]
        public IEnumerable<Category> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.CategoryBusiness.ReadAll();
            }
        }
        //GET api/category/{Guid}
        [HttpGet]
        [Route("{categoryId:Guid}")]
        public Category ReadById(Guid categoryId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.CategoryBusiness.ReadById(categoryId);
            }
        }
        //POST api/category
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] Category category)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.CategoryBusiness.Insert(category);
            }
        }
        //DELETE api/category/{Guid}
        [HttpDelete]
        [Route("{categoryId:Guid}")]
        public void Delete(Guid categoryId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.CategoryBusiness.Delete(categoryId);
            }
        }
        //PUT api/category
        [HttpPut]
        [Route("")]
        public void Update(Category category)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.CategoryBusiness.Update(category);
            }
        }
    }
}