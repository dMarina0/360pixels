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
        #region ReadAll

        
        public List<Category> ReadAll()
        {

            return ReadAll("Categories_ReadAll");

        }

        protected override Category GetModelfromReader(SqlDataReader reader)
        {
            Category category = new Category();
            category.CategoryID = reader.GetGuid(reader.GetOrdinal("CategoryID"));
            category.CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"));
            return category;
        }
        #endregion
        #region Insert

        public void Insert(Category category)
        {

            Insert("Categories_Create", AddParameter(category));
            
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
        #endregion

        public void Delete(Guid categoryID)
        {
            Delete("Categories_Delete", SetID(categoryID));

        }
        protected override SqlParameter[] SetID(Guid categoryID)
        {

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("CategoryID", categoryID)
            };


            return parameter;

        }




        public void Update(Category category)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Categories_Update";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("CategoryID", category.CategoryID));
                    command.Parameters.Add(new SqlParameter("CategoryName", category.CategoryName));
                    

                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Exception : {0} ", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        
        public Category ReadById(Guid categoryID)
        {
                return ReadByID("Categories_ReadById", SetID(categoryID)).First();

        }

        


    }
}
