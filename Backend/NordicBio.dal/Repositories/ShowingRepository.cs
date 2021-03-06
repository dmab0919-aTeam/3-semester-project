﻿
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
            _configuration = configuration;
            _constring = _configuration.GetConnectionString("constring");
        }

        // Get all showings on a movie by movie_id
        public async Task<IEnumerable<Showing>> GetShowingsByIDAsync(int id)
        {
            var parameters = new { Id = id };
            const string sql = "SELECT * FROM [Showings] WHERE [MovieID] = @Id " +
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
            const string sql = "SELECT * FROM [Showings]" +
                               "ORDER BY [ShowingTime]";

            using (var connection = new SqlConnection(_constring))
            {
                var res = await connection.QueryAsync<Showing>(sql);
                return res.ToList();
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
            const string sql = "DELETE FROM [Showings] WHERE [Id] = @ShowingID";
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

        public async Task<int> UpdateAsync(Showing entity)
        {
            const string sql = "UPDATE [Showings] SET " +
                               "[Price] = @Price, " +
                               "[ShowingTime] = @ShowingTime, " +
                               "[HallNumber] = @HallNumber, " +
                               "[MovieID] = @MovieID " +
                               "WHERE [Showings].Id = @Id";

            var parameters = new
            {
                Price = entity.Price,
                ShowingTime = entity.ShowingTime,
                HallNumber = entity.HallNumber,
                MovieID = entity.MovieID,
                Id = entity.Id
            };

            Console.WriteLine(entity.Id);
            Console.WriteLine(entity.Price);
            Console.WriteLine(entity.MovieID);
            Console.WriteLine(entity.ShowingTime);

            using (SqlConnection connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.ExecuteAsync(sql, parameters);
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    throw new Exception("Denne showing findes ikke");
                }
            }
        }

        public async Task<Showing> GetByIDAsync(int id)
        {
            const string sql = "SELECT * FROM [Showings] WHERE [id] = @Id";
            var parameters = new { Id = id };
            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.QuerySingleOrDefaultAsync<Showing>(sql, parameters);
                    return result;
                }
                catch (Exception)
                {
                    throw new Exception("Showing Findes ikke");
                }
            }
        }
    }
}
