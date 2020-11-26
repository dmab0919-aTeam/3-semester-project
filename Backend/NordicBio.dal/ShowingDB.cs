
using Dapper;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NordicBio.dal
{
    public class ShowingDB : ICRUD<Showing>
    {
        private string _constring;
        public ShowingDB(string constring)
        {
            _constring = constring;
        }


        // Get all showings on a movie by movie_id
        public IEnumerable<Showing> getShowingsByID(int id)
        {
            var parameters = new { MovieID = id };
            string sql = "SELECT * FROM Showings WHERE MovieID = @MovieID ORDER BY ShowingTime";
            List<Showing> res;

            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    res = connection.Query<Showing>(sql, parameters).ToList();
                }
                catch (Exception)
                {
                    throw new Exception("Filmen Findes ikke");
                }
            }

            return res;
        }

        public bool Create(Showing t)
        {
            bool res = false;
            var parameters = new
            {
                Price = t.Price,
                ShowingTime = t.ShowingTime,
                HallNumber = t.HallNumber,
                MovieID = t.MovieID
            };
            var sql = "INSERT INTO Showings " +
                "(Price, ShowingTime, HallNumber, MovieID) " +
                "VALUES (@Price, @ShowingTime, @HallNumber, @MovieID);";


            using (SqlConnection con = new SqlConnection(_constring))
            {
                try
                {
                    con.Execute(sql, parameters);
                    res = true;
                }
                catch (Exception)
                {
                    throw new Exception("Showing blev ikke oprettet");
                }
            }

            return res;
        }

        public Showing Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Showing> GetAll()
        {
            string sql = "SELECT * FROM Showings";
            List<Showing> res;


            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    res = connection.Query<Showing>(sql).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return res;
        }

        public bool Update(Showing t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Showing t)
        {
            throw new NotImplementedException();
        }
    }
}
