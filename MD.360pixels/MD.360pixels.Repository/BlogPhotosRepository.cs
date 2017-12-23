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
    public class BlogPhotosRepository : BaseRepository<BlogPhoto> , IBlogPhotosRepository
    {
        public void Insert(BlogPhoto BlogPhoto)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("BlogID",BlogPhoto.BlogID),
                new SqlParameter("PhotoID",BlogPhoto.PhotoID)
            };

            Insert("BlogPhotos_Create", parameter);
        }

        public void Delete(Guid BlogID, Guid PhotoID)
        {
            SqlParameter[] parameter = new SqlParameter[]
             {
                new SqlParameter("BlogID", BlogID),
                new SqlParameter("PhotoID",PhotoID)
             };

            Delete("BlogPhotos_Delete", parameter);
        }

        public List<BlogPhoto> ReadAll()
        {
            return ReadAll("BlogPhotos_ReadAll");
        }

        protected override BlogPhoto GetModelfromReader(SqlDataReader reader)
        {
            BlogPhoto BlogPhoto = new BlogPhoto();
            BlogPhoto.BlogID = reader.GetGuid(reader.GetOrdinal("BlogID"));
            BlogPhoto.PhotoID = reader.GetGuid(reader.GetOrdinal("PhotoID"));

            return BlogPhoto;
        }
    }
}
