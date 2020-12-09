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
    public class MovieRepository : IMovieRepository

    {
        private readonly IConfiguration _configuration;
        private readonly string _constring;

        public MovieRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._constring = _configuration.GetConnectionString("constring");
        }
        public async Task<int> Add(Movie entity)
        {
            var sql = "INSERT INTO [Movies] (Title, ReleaseDate, VoteAverage, PosterPath, Description) " +
                        "VALUES (@Title, @ReleaseDate, @VoteAverage, @PosterPath, @Description)";

            var parameters = new
            {
                Title = entity.Title,
                ReleaseDate = entity.ReleaseDate,
                VoteAverage = entity.VoteAverage,
                PosterPath = entity.PosterPath,
                Description = entity.Description
            };
            using (var connection = new SqlConnection(_constring))
            {
                var result = await connection.ExecuteAsync(sql, parameters);
                return result;
            }
        }
        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM [Movies] WHERE [id] = @Id";
            var parameters = new { Id = id };
            using (var conneciton = new SqlConnection(_constring))
            {
                try
                {
                    var result = await conneciton.ExecuteAsync(sql, parameters);
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public async Task<IEnumerable<Movie>> GetAll()
        {
            var sql = "SELECT * FROM [Movies]";

            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.QueryAsync<Movie>(sql);
                    return result.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public async Task<Movie> GetByID(int id)
        {
            var sql = "SELECT * FROM Movies WHERE id = @Id";
            var parameters = new { Id = id };
            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.QuerySingleOrDefaultAsync<Movie>(sql, parameters);
                    return result;
                }
                catch (Exception)
                {
                    throw new Exception("Filmen Findes ikke");
                }
            }
        }
        public async Task<int> Update(Movie entity)
        {
            var sql = "UPDATE [Movies] SET Title = @Title, ReleaseDate = @ReleaseDate, " +
                            "VoteAverage = @VoteAverage, PosterPath = @PosterPath, BackdropPath = @BackdropPath, Description = @Description  " +
                            "WHERE Id = @Id";
            using (var connection = new SqlConnection(_constring))
            {
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}

