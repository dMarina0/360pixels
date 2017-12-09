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
    public class UserProfileRepository :BaseRepository<UserProfile>
    {
        

        #region ReadALL
        public List<UserProfile> ReadAll()
        {
            return ReadAll("UserProfile_ReadAll");
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
        #endregion
        #region Insert

        
        public void Insert(UserProfile user)
        {

            Insert("UserProfile_Create", AddParameter(user));
           
        }
        protected override SqlParameter[] AddParameter(UserProfile user)
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

            #endregion
        public void Delete(Guid userID)
        {
            Delete("UserProfile_Delete", SetID(userID));

        }

        protected override SqlParameter[] SetID(Guid userID)
        {

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("UserID", userID)
            };

            return parameter;
        }



        public void Update(UserProfile user)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "UserProfile_Update";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("UserID", user.UserID));
                    command.Parameters.Add(new SqlParameter("UserName", user.UserName));
                    command.Parameters.Add(new SqlParameter("FirstName", user.FirstName));
                    command.Parameters.Add(new SqlParameter("LastName", user.LastName));
                    command.Parameters.Add(new SqlParameter("BirthDay", user.BirthDay));
                    command.Parameters.Add(new SqlParameter("Camera", user.Camera));
                    command.Parameters.Add(new SqlParameter("Country", user.Country));
                    command.Parameters.Add(new SqlParameter("Website", user.Website));

                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch(SqlException ex)
                {
                    Console.WriteLine("Exception : {0} ", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public UserProfile ReadById(Guid userID)
        {
            List<UserProfile> list = new List<UserProfile>();
            list = ReadByID("UserProfie_ReadById", SetID(userID)) ;
            return list.FirstOrDefault() ;

        }

   
    }
}
