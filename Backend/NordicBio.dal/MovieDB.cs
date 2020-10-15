using Dapper;
using NordicBio.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NordicBio.dal
{
    public class MovieDB
    {
        public IEnumerable<Movie> GetAllMovies()
        {
            string constring = "Server=(localdb)\\mssqllocaldb; Database=NordicBio; Trusted_connection=true";
            string sql = "SELECT * FROM Movies";
            List<Movie> res;

            using (var connection = new SqlConnection(constring))
            {
                res = connection.Query<Movie>(sql).ToList();
            }
            return res;
        }
    }
}
