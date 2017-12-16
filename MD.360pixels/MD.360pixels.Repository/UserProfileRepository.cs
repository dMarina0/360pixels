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
    public class UserProfileRepository :BaseRepository<UserProfile>,IUserProfileRepository
    {
        
        public List<UserProfile> ReadAll()
        {
            return ReadAll("UserProfile_ReadAll");
        }

        
        public void Insert(UserProfile user)
        {

            Insert("UserProfile_Create", GetParameter(user));
           
        }
       
          
        public void Delete(Guid userID)
        {
            Delete("UserProfile_Delete", SetID(userID));

        }


        public void Update(UserProfile user)
        {

            Update("UserProfile_Update", GetParameter(user));
            
        }

        public UserProfile ReadById(Guid userID)
        {
            return ReadByID("UserProfie_ReadById", new SqlParameter("UserID", userID)) ;
        }


        protected override SqlParameter[] SetID(Guid userID)
        {

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("UserID", userID)
            };

            return parameter;
        }
        protected override UserProfile GetModelfromReader(SqlDataReader reader)
        {
            UserProfile user = new UserProfile();
            user.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            user.UserName = reader.GetString(reader.GetOrdinal("UserName"));
            user.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
            user.LastName = reader.GetString(reader.GetOrdinal("LastName"));
            user.BirthDay = reader.GetDateTime(reader.GetOrdinal("BirthDay"));
            user.Camera = reader.GetString(reader.GetOrdinal("Camera"));
            user.Country = reader.GetString(reader.GetOrdinal("Country"));
            user.Camera = reader.GetString(reader.GetOrdinal("Camera"));
            user.Website = reader.GetString(reader.GetOrdinal("Website"));

            return user;
        }
        protected override SqlParameter[] GetParameter(UserProfile user)
        {

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("UserID", user.UserID),
                new SqlParameter("UserName", user.UserName),
                new SqlParameter("FirstName", user.FirstName),
                new SqlParameter("LastName", user.LastName),
                new SqlParameter("BirthDay", user.BirthDay),
                new SqlParameter("Camera", user.Camera),
                new SqlParameter("Country", user.Country),
                new SqlParameter("Website", user.Website)

            };


            return parameter;
        }

    }
}
