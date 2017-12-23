using MD._360pixels.Repository.Core;
using MD._360pixels.RepositoryAbstraction;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Repository
{

   public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {
        public List<Category> ReadAll()
        {

            return ReadAll("Categories_ReadAll");

        }

       
        public void Insert(Category category)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("CategoryID", category.CategoryID),
                new SqlParameter("CategoryName", category.CategoryName),

            };
            Insert("Categories_Create", parameter);
            
        }
        
      
        public void Delete(Guid categoryID)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
            new SqlParameter("CategoryID", categoryID)
            };
           
            Delete("Categories_Delete", parameter);

        }
        
      
        public void Update(Category category)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("CategoryID", category.CategoryID),
                new SqlParameter("CategoryName", category.CategoryName),

            };
            Update("Categories_Update", parameter);
        }
       
       
        public Category ReadById(Guid categoryID)
        {
            SqlParameter parameter = new SqlParameter("CategoryID", categoryID);
            
            return ReadByID("Categories_ReadById",parameter);

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
