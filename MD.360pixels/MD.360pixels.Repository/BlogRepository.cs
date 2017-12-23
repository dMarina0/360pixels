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
    public class BlogRepository: BaseRepository<Blog>, IBlogRepository
    {

        public List<Blog> ReadAll()
        {
           
            return ReadAll("Blog_ReadAll");
        }
       
        public void Insert(Blog blog)
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

            Insert("Blog_Create", parameter);
        }

        
        public void Delete(Guid blogID)
        {

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("BlogID", blogID)
            };
            Delete("Blog_Delete", parameter);
                 

        }
        
        
        public void Update(Blog blog)
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
            Update("Blog_Update", parameter);
           
        }
      
        public Blog ReadById(Guid blogID)
        {
            SqlParameter parameter = new SqlParameter("BlogID", blogID);
            return ReadByID("Blog_ReadById", parameter);
            
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


    }
}
