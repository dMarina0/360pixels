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

            Insert("Photos_Create", GetParameter(photo));
                    
        }


        public void Delete(Guid photoID)
        {
            Delete("Photos_Delete", SetID(photoID));
              

        }

        public void Update(Photos photo)
        {
            Update("Photos_Update", GetParameter(photo));
                    
        }

        public Photos ReadById(Guid photoID)
        {
            return ReadByID("Photos_ReadByID", new SqlParameter("PhotoID", photoID));
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
        protected override SqlParameter[] GetParameter(Photos photo)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("PhotoID", photo.PhotoID),
                new SqlParameter("Photo", photo.Photo),
                new SqlParameter("Likes", photo.Likes),
                new SqlParameter("Location", photo.Location),
                new SqlParameter("Comments", photo.Comment)

            };


            return parameter;
        }
        protected override SqlParameter[] SetID(Guid photoID)
        {


            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("PhotoID", photoID)
            };


            return parameter;

        }

        
    }
    
    
}
