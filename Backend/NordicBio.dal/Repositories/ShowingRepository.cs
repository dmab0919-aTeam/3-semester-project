
using Dapper;
using Microsoft.Extensions.Configuration;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NordicBio.dal
{
    public class ShowingRepository : IShowingRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _constring;

        public ShowingRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._constring = _configuration.GetConnectionString("constring");
        }

        // Get all showings on a movie by movie_id
        public async Task<IEnumerable<Showing>> GetShowingsByID(int id)
        {
            var parameters = new { Id = id };
            string sql = "SELECT * FROM Showings WHERE MovieID = @Id";

            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    var res = await connection.QueryAsync<Showing>(sql, parameters);
                    return res.ToList();
                }
                catch (Exception)
                {
                    throw new Exception("Filmen Findes ikke");
                }
            }
        }
        public async Task<IEnumerable<Showing>> GetAll()
        {
            string sql = "SELECT * FROM Showings";


            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    var res = await connection.QueryAsync<Showing>(sql);
                    return res.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public async Task<int> Add(Showing entity)
        {
            var parameters = new
            {
                Price = entity.Price,
                ShowingTime = entity.ShowingTime,
                HallNumber = entity.HallNumber,
                MovieID = entity.MovieID
            };
            var sql = "INSERT INTO Showings " +
                "(Price, ShowingTime, HallNumber, MovieID) " +
                "VALUES (@Price, @ShowingTime, @HallNumber, @MovieID);";

            using (SqlConnection con = new SqlConnection(_constring))
            {
                try
                {
                    var res = await con.ExecuteAsync(sql, parameters);
                    return res;
                }
                catch (Exception)
                {
                    throw new Exception("Showing blev ikke oprettet");
                }
            }
        }

        // NOT IMPLEMENTET

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Showing entity)
        {
            throw new NotImplementedException();
        }
        public Task<Showing> GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
