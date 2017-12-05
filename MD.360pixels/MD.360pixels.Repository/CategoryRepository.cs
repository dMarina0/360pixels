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

        public void Insert(Category category)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Categories_Create";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("CategoryID", category.CategoryID));
                    command.Parameters.Add(new SqlParameter("CategoryName", category.CategoryName));
                   

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException Ex)
                {
                    Console.WriteLine("Exception : {0}", Ex.ToString());
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void Delete(Guid categoryID)
        {
            string StringConnection = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Categories_Delete";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    Category category = new Category();
                    category.CategoryID = categoryID;
                    command.Parameters.Add(new SqlParameter("CategoryID", category.CategoryID));
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Exception: {0} ", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }

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

        public  Category ReadById(Guid categoryID)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";
            Category category = new Category();
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Categories_ReadById";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    category.CategoryID = categoryID;
                    command.Parameters.Add(new SqlParameter("CategoryID", category.CategoryID));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            category.CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"));
                            
                        }
                    }

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
            return category;
        }
    }
}
