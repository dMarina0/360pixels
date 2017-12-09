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
    public class BlogRepository: BaseRepository<Blog>
    {
        #region ReadAll

        
        public List<Blog> ReadAll()
        {
            return ReadAll("Blog_ReadAll");
        }

        protected override Blog GetModelfromReader(SqlDataReader reader)
        {
            Blog blog = new Blog();
            blog.BlogID = reader.GetGuid(reader.GetOrdinal("BlogID"));
            blog.Title = reader.GetString(reader.GetOrdinal("Title"));
            blog.Author = reader.GetString(reader.GetOrdinal("Author"));
            blog.Content = reader.GetString(reader.GetOrdinal("Content"));
            blog.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
            blog.Type = reader.GetString(reader.GetOrdinal("Type"));
            return blog;
        }
        #endregion

        #region Insert

        
        public void Insert(Blog blog)
        {

            Insert("Blog_Create", AddParameter(blog));
                   
            
        }

        protected override SqlParameter[] AddParameter(Blog blog)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("BlogID", blog.BlogID),
                new SqlParameter("Title", blog.Title),
                new SqlParameter("Author", blog.Author),
                new SqlParameter("Content", blog.Content),
                new SqlParameter("Date", blog.Date),
                new SqlParameter("Type", blog.Type)

            };


            return parameter;
         }

        #endregion

        public void Delete(Guid blogID)
        {

            Delete("Blog_Delete", SetID(blogID));
                 

        }

        protected override SqlParameter[] SetID(Guid blogID)
        {
            

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("BlogID", blogID)
            };


            return parameter;



        }

        public void Update(Blog blog)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Blog_Update";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("BlogID", blog.BlogID));
                    command.Parameters.Add(new SqlParameter("Title", blog.Title));
                    command.Parameters.Add(new SqlParameter("Author", blog.Author));
                    command.Parameters.Add(new SqlParameter("Content", blog.Content));
                    command.Parameters.Add(new SqlParameter("Date", blog.Date));
                    command.Parameters.Add(new SqlParameter("Type", blog.Type));


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

        public Blog ReadById(Guid blogID)
        {
             return ReadByID("Blog_ReadById", SetID(blogID)).First();
            
        }

      
    }
}
