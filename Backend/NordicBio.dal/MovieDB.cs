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
        private string _constring;

        public MovieDB(string constring)
        {
            this._constring = constring;
        }

        public IEnumerable<Movie> GetAllMovies()
        {

            string sql = "SELECT * FROM Movies";
            List<Movie> res;


            using (var connection = new SqlConnection(_constring))
            {
                res = connection.Query<Movie>(sql).ToList();
            }
            return res;
        }
    }
}
