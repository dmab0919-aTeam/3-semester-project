using Dapper;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NordicBio.dal
{
    public class MovieDB : ICRUD<Movie>

    {
        private string _constring;

        public MovieDB(string constring)
        {
            this._constring = constring;
        }


        // CRUD Functionality
        public bool Create(Movie t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Movie t)
        {
            throw new NotImplementedException();
        }

        public Movie Get(int id)
        {
            var parameters = new { Id = id };
            string sql = "SELECT * FROM Movies WHERE id = @Id";
            Movie res;

            using (var connection = new SqlConnection(_constring))
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

        public IEnumerable<Movie> GetAll()
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

        public bool Update(Movie t)
        {
            throw new NotImplementedException();
        }
    }
}
