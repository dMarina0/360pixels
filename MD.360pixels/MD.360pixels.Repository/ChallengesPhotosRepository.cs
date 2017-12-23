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
    public class ChallengesPhotosRepository : BaseRepository <ChallengePhoto>, IChallengesPhotosRepository
    {
        public void Insert(ChallengePhoto ChallengePhoto)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("ChallengeID", ChallengePhoto.ChallengeID),
                new SqlParameter("PhotoID",ChallengePhoto.PhotoID)
            };

            Insert("ChallengesPhotos_Create", parameter);
        }

        public void Delete(Guid ChallengeID, Guid PhotoID)
        {
            SqlParameter[] parameter = new SqlParameter[]
             {
                new SqlParameter("ChallengeID", ChallengeID),
                new SqlParameter("PhotoID",PhotoID)
             };

            Delete("ChallengesPhotos_Delete", parameter);
        }

        public List<ChallengePhoto> ReadAll()
        {
            return ReadAll("ChallengesPhotos_ReadAll");
        }

        protected override ChallengePhoto GetModelfromReader(SqlDataReader reader)
        {
            ChallengePhoto ChallengePhoto = new ChallengePhoto();
            ChallengePhoto.ChallengeID = reader.GetGuid(reader.GetOrdinal("ChallengeID"));
            ChallengePhoto.PhotoID = reader.GetGuid(reader.GetOrdinal("PhotoID"));

            return ChallengePhoto;
        }
    }
}
