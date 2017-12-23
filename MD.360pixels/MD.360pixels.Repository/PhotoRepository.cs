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
    public class PhotoRepository: BaseRepository<Photos> , IPhotoRepository
    {
        
        public List<Photos> ReadAll()
        {

            return ReadAll("Photos_ReadAll");
            
        }

        public void Insert(Photos photo)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("PhotoID", photo.PhotoID),
                new SqlParameter("Photo", photo.Photo),
                new SqlParameter("Likes", photo.Likes),
                new SqlParameter("Location", photo.Location),
                new SqlParameter("Comments", photo.Comment)

            };
            Insert("Photos_Create", parameter);
                    
        }


        public void Delete(Guid photoID)
        {

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("PhotoID", photoID)
            };

            Delete("Photos_Delete", parameter);
              

        }

        public void Update(Photos photo)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("PhotoID", photo.PhotoID),
                new SqlParameter("Photo", photo.Photo),
                new SqlParameter("Likes", photo.Likes),
                new SqlParameter("Location", photo.Location),
                new SqlParameter("Comments", photo.Comment)

            };
            Update("Photos_Update", parameter);
                    
        }

        public Photos ReadById(Guid photoID)
        {
            SqlParameter parameter = new SqlParameter("PhotoID", photoID);
            
            return ReadByID("Photos_ReadByID", parameter);
        }


        protected override Photos GetModelfromReader(SqlDataReader reader)
        {

            Photos photo = new Photos();
            photo.PhotoID = reader.GetGuid(reader.GetOrdinal("PhotoID"));
            photo.Photo = reader.GetString(reader.GetOrdinal("Photo"));
            photo.Likes = reader.GetInt32(reader.GetOrdinal("Likes"));
            photo.Location = reader.GetString(reader.GetOrdinal("Location"));
            photo.Comment = reader.GetString(reader.GetOrdinal("Comments"));
            return photo;
        }
     
    }
    
    
}
