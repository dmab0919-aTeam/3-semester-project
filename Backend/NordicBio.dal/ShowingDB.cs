
using Dapper;
using NordicBio.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NordicBio.dal
{
    public class ShowingDB
    {
        private string _constring;
        public ShowingDB(string constring)
        {
            _constring = constring;
        }


        public bool CreateShowing(Showing showing)
        {
            bool res = false;
            var parameters = new
            {
                Price = showing.Price,
                ShowingTime = showing.ShowingTime,
                HallNumber = showing.HallNumber,
                MovieID = showing.MovieID
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

        // Get all showings on a movie by movie_id
        public IEnumerable<Showing> getShowingsByID(int id)
        {
            var parameters = new { Id = id };
            string sql = "SELECT * FROM Showings WHERE MovieID = @Id";
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


        public IEnumerable<Showing> getAllShowings()
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
    }
}
