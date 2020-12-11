
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
        public async Task<IEnumerable<Showing>> GetShowingsByIDAsync(int id)
        {
            var parameters = new { Id = id };
            string sql = "SELECT * FROM [Showings] WHERE [MovieID] = @Id " +
                "ORDER BY [id]";

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
        public async Task<IEnumerable<Showing>> GetAllAsync()
        {
            string sql = "SELECT * FROM [Showings]" +
                "ORDER BY [ShowingTime]";

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
        public async Task<int> AddAsync(Showing entity)
        {
            var parameters = new
            {
                Price = entity.Price,
                ShowingTime = entity.ShowingTime,
                HallNumber = entity.HallNumber,
                MovieID = entity.MovieID
            };
            var sql = "INSERT INTO [Showings] " +
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

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM [Showings] WHERE [Id] = @ShowingID";
            var parameters = new { ShowingID = id };

            using (SqlConnection connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.ExecuteAsync(sql, parameters);
                    return result;
                }
                catch (Exception)
                {
                    throw new Exception("Denne showing findes ikke");
                }
            }
        }

        public Task<int> UpdateAsync(Showing entity)
        {
            throw new NotImplementedException();
        }
        public Task<Showing> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
