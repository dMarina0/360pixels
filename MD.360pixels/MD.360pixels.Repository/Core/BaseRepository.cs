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

        protected abstract TModel GetModelfromReader(SqlDataReader reader);


    }
}
