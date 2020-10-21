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

			string cnstr = System.Configuration.ConfigurationManager.ConnectionStrings["myCustomConnString"].ConnectionString;

			Console.WriteLine(cnstr);

			//string dbTest = ConfigurationManager.AppSettings["myCustomConnString"];

            using (var connection = new SqlConnection(cnstr))
            {
                res = connection.Query<Movie>(sql).ToList();
            }
            return res;
        }
    }
}
