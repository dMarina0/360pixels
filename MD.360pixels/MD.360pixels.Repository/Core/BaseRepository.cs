using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Repository.Core
{
    public abstract class  BaseRepository<TModel>
    {

        protected static string connectionString= GetConnectionString();

        private static string GetConnectionString()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["360pixelsDB"];
            if (connectionStringSettings == null)
            {
                throw new ArgumentNullException("No connection string defined in the configuration file!");
            }

            return connectionStringSettings.ConnectionString;
        }

        public List<TModel> ReadAll (string storedProcedure , SqlParameter[] parameters=default(SqlParameter[]))
        {
            List<TModel> result = new List<TModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())

                    {
                        command.Connection = connection;
                        command.CommandText = storedProcedure;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        if(parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                result.Add(GetModelfromReader(reader));
                            }
                                
                        }
                    }
                }
                catch(SqlException ex)
                {
                    Console.WriteLine("Excetion : {0} ", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        public void Insert(string storedProcedure, SqlParameter[] parameters= default(SqlParameter[]))
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = storedProcedure;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(SqlException ex)
                {
                    Console.WriteLine("Exception: {0} ", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Delete(String storedProcedure, SqlParameter[] parameters = default(SqlParameter[]))
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = storedProcedure;
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

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

        public TModel ReadByID(string storedProcedure, SqlParameter parameter = default(SqlParameter))
        {
            List<TModel> result = new List<TModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())

                    {
                        command.Connection = connection;
                        command.CommandText = storedProcedure;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        if (parameter != null)
                        {
                            command.Parameters.Add(parameter);
                        }
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                               result.Add(GetModelfromReader(reader));
                            }

                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Excetion : {0} ", ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return result.Single();
        }

        public void Update(string storedProcedure, SqlParameter[] parameters = default(SqlParameter[]))
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = storedProcedure;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

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



        protected abstract TModel GetModelfromReader(SqlDataReader reader);
        protected abstract SqlParameter[] GetParameter(TModel model);
        protected abstract SqlParameter[] SetID(Guid guid);

    }
}
