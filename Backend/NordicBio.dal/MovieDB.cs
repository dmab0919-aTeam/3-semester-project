using Dapper;
using NordicBio.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;

namespace NordicBio.dal
{
    public class MovieDB
    {
        public IEnumerable<Movie> GetAllMovies()
        {
            
            string sql = "SELECT * FROM Movies";
            List<Movie> res;

			Console.WriteLine(ConfigurationManager.AppSettings["myCustomConnString"]);

			var connectionString = ConfigurationManager.AppSettings["myCustomConnString"];

			Console.WriteLine(connectionString);

            using (var connection = new SqlConnection(connectionString))
            {
                res = connection.Query<Movie>(sql).ToList();
            }
            return res;
        }
    }
}
