using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Repository
{
    public class BlogRepository
    {

        public List<Blog> ReadAll()
        {
            List<Blog> blogs = new List<Blog>();

            string connectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "Blog_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Blog blog = new Blog();
                                blog.BlogID = reader.GetGuid(reader.GetOrdinal("BlogID"));
                                blog.Title = reader.GetString(reader.GetOrdinal("Title"));
                                blog.Author = reader.GetString(reader.GetOrdinal("Author"));
                                blog.Content = reader.GetString(reader.GetOrdinal("Content"));
                                blog.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                                blog.Type = reader.GetString(reader.GetOrdinal("Type"));
                                
                                blogs.Add(blog);
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

            return blogs;
        }


        public void Insert(Blog blog)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Blog_Create";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("BlogID", blog.BlogID));
                    command.Parameters.Add(new SqlParameter("Title", blog.Title));
                    command.Parameters.Add(new SqlParameter("Author", blog.Author));
                    command.Parameters.Add(new SqlParameter("Content", blog.Content));
                    command.Parameters.Add(new SqlParameter("Date", blog.Date));
                    command.Parameters.Add(new SqlParameter("Type", blog.Type));
                   

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

        public void Delete(Guid blogID)
        {
            string StringConnection = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Blog_Delete";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    Blog blog = new Blog();
                    blog.BlogID = blogID;
                    command.Parameters.Add(new SqlParameter("BlogID", blog.BlogID));
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

        public void Update(Blog blog)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Blog_Update";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("BlogID", blog.BlogID));
                    command.Parameters.Add(new SqlParameter("Title", blog.Title));
                    command.Parameters.Add(new SqlParameter("Author", blog.Author));
                    command.Parameters.Add(new SqlParameter("Content", blog.Content));
                    command.Parameters.Add(new SqlParameter("Date", blog.Date));
                    command.Parameters.Add(new SqlParameter("Type", blog.Type));


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

        public Blog ReadById(Guid blogID)
        {
            string ConnectionString = "Server =DESKTOP-2HQ1GA6 ; Database =test3; Trusted_Connection = True; ";
            Blog blog = new Blog();
           
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "Blog_ReadById";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    blog.BlogID = blogID;
                    command.Parameters.Add(new SqlParameter("BlogID", blog.BlogID));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            blog.BlogID = reader.GetGuid(reader.GetOrdinal("BlogID"));
                            blog.Title = reader.GetString(reader.GetOrdinal("Title"));
                            blog.Author = reader.GetString(reader.GetOrdinal("Author"));
                            blog.Content = reader.GetString(reader.GetOrdinal("Content"));
                            blog.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                            blog.Type = reader.GetString(reader.GetOrdinal("Type"));
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
            return blog;
        }
    }
}
