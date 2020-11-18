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
                try
                {
                    res = connection.Query<Movie>(sql).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
            return res;
        }

        public Movie GetMovie(int id)
        {
            var parameters = new { Id = id };
            string sql = "SELECT * FROM Movies WHERE id = @Id";
            Movie res;

            using(var connection = new SqlConnection(_constring))
            {
                try
                {
                    res = connection.QuerySingleOrDefault<Movie>(sql, parameters);
                }
                catch (Exception)
                {
                    throw new Exception("Filmen Findes ikke");
                }
            }

            return res;
        }
    }
}
