using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Repository
{
    public class PhotoRepository
    {
        public List<Photos> ReadAll()
        {
            List<Photos> photos = new List<Photos>();

            string connectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "Photos_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Photos photo = new Photos();
                                photo.PhotoID = reader.GetGuid(reader.GetOrdinal("PhotoID"));
                                photo.Photo = reader.GetString(reader.GetOrdinal("Photo"));
                                photo.Likes = reader.GetInt32(reader.GetOrdinal("Likes"));
                                photo.Location = reader.GetString(reader.GetOrdinal("Location"));
                                photo.Comment = reader.GetString(reader.GetOrdinal("Comments"));
                               

                                photos.Add(photo);
                            }
                        }

                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Exception : {0}", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }

            return photos;
        }
        public void Insert(Photos photo)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Photos_Create";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("PhotoID", photo.PhotoID));
                    command.Parameters.Add(new SqlParameter("Photo", photo.Photo));
                    command.Parameters.Add(new SqlParameter("Likes", photo.Likes));
                    command.Parameters.Add(new SqlParameter("Location", photo.Location));
                    command.Parameters.Add(new SqlParameter("Comments", photo.Comment));
                    


                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException Ex)
                {
                    Console.WriteLine("Exception : {0}", Ex.ToString());
                }
                finally
                {
                    connection.Close();
                }

            }
        }
        public void Delete(Photos photo)
        {
            string StringConnection = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Photos_Delete";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("PhotoID", photo.PhotoID));
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Exception: {0} ", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }

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

        public Photos ReadById(Photos photo)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Photos_ReadByID";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("PhotoID", photo.PhotoID));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            photo.Photo = reader.GetString(reader.GetOrdinal("Photo"));
                            photo.Likes = reader.GetInt32(reader.GetOrdinal("Likes"));
                            photo.Location = reader.GetString(reader.GetOrdinal("Location"));
                            photo.Comment = reader.GetString(reader.GetOrdinal("Comments"));
                        }
                    }

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
            return photo;
        }
    }
}
