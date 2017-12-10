using MD._360pixels.Repository.Core;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Repository
{

   public class CategoryRepository:BaseRepository<Category>
    {
        public List<Category> ReadAll()
        {

            return ReadAll("Categories_ReadAll");

        }

       
        public void Insert(Category category)
        {

            Insert("Categories_Create", AddParameter(category));
            
        }
        
      
        public void Delete(Guid categoryID)
        {
            Delete("Categories_Delete", SetID(categoryID));

        }
        
      
        public void Update(Category category)
        {
            Update("Categories_Update", AddParameter(category));
        }
       
       
        public Category ReadById(Guid categoryID)
        {
                return ReadByID("Categories_ReadById", SetID(categoryID)).First();

        }
        

        protected override SqlParameter[] AddParameter(Category category)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("CategoryID", category.CategoryID),
                new SqlParameter("CategoryName", category.CategoryName),

            };


            return parameter;
        }
        protected override SqlParameter[] SetID(Guid categoryID)
        {

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("CategoryID", categoryID)
            };


            return parameter;

        }
        protected override Category GetModelfromReader(SqlDataReader reader)
        {
            Category category = new Category();
            category.CategoryID = reader.GetGuid(reader.GetOrdinal("CategoryID"));
            category.CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"));
            return category;
        }


    }
}
