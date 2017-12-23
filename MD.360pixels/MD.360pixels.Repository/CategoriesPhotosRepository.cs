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
    public class CategoriesPhotosRepository : BaseRepository<CategoryPhoto> , ICategoriesPhotosRepository
    {
        public void Insert(CategoryPhoto CategoryPhoto)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("CategoryID",CategoryPhoto.CategoryID),
                new SqlParameter("PhotoID", CategoryPhoto.PhotoID)
            };

            Insert("CategoriesPhotos_Create", parameter);
        }

        public void Delete(Guid CategoryID, Guid PhotoID)
        {
            SqlParameter[] parameter = new SqlParameter[]
             {
                new SqlParameter("CategoryID", CategoryID),
                new SqlParameter("PhotoID",PhotoID)
             };

            Delete("CategoriesPhotos_Delete", parameter);
        }

        public List<CategoryPhoto> ReadAll()
        {
            return ReadAll("CategoriesPhotos_ReadAll");
        }

        protected override CategoryPhoto GetModelfromReader(SqlDataReader reader)
        {
            CategoryPhoto CategoryPhoto = new CategoryPhoto();
            CategoryPhoto.CategoryID = reader.GetGuid(reader.GetOrdinal("CategoryID"));
            CategoryPhoto.PhotoID = reader.GetGuid(reader.GetOrdinal("PhotoID"));

            return CategoryPhoto;
        }
    }
}
