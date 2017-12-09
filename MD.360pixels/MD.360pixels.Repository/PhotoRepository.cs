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
    public class PhotoRepository: BaseRepository<Photos>
    {
        #region ReadAll

        
        public List<Photos> ReadAll()
        {

            return ReadAll("Photos_ReadAll");
            
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
        #endregion
            #region Insert
        public void Insert(Photos photo)
        {

            Insert("Photos_Create", AddParameter(photo));
                    
        }


        protected override SqlParameter[] AddParameter(Photos photo)
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
        #endregion


        public void Delete(Guid photoID)
        {
            Delete("Photos_Delete", SetID(photoID));
              

        }
        protected override SqlParameter[] SetID(Guid photoID)
        {
            

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("PhotoID", photoID)
            };


            return parameter;

        }

        public void Update(Photos photo)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Photos_Update";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("PhotoID", photo.PhotoID));
                    command.Parameters.Add(new SqlParameter("Photo", photo.Photo));
                    command.Parameters.Add(new SqlParameter("Likes", photo.Likes));
                    command.Parameters.Add(new SqlParameter("Location", photo.Location));
                    command.Parameters.Add(new SqlParameter("Comments", photo.Comment));


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

        public Photos ReadById(Guid photoID)
        {
            return ReadByID("Photos_ReadByID", SetID(photoID)).First();
        }

        

    }
    
    
}
