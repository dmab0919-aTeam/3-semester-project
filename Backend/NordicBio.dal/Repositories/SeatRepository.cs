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
    public class SeatRepository : ISeatRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _constring;

        public SeatRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._constring = _configuration.GetConnectionString("constring");
        }
        public async Task<int> Add(Seat entity)
        {
            int res;
            string sql = "INSERT INTO Seats (Row, Number, OrderID) VALUES (@Row, @Number, @OrderID)";
            var parameters = new
            {
                Row = entity.Row,
                Number = entity.Number,
                OrderID = entity.OrderID
            };

            using (SqlConnection con = new SqlConnection(_constring))
            {
                res = await con.ExecuteAsync(sql, parameters);
                return res;
            }
        }
        public async Task<IEnumerable<Seat>> GetAll()
        {
            string sql = "SELECT * FROM [Seats]";

            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.QueryAsync<Seat>(sql);
                    return result.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public async Task<IEnumerable<Seat>> GetAllById(int id)
        {
            var sql = "SELECT * FROM [Seats] WHERE ShowingID = @Id";
            var parameters = new { Id = id };

            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.QueryAsync<Seat>(sql, parameters);
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // NOT IMPLEMENTET

        public Task<Seat> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Seat entity)
        {
            throw new NotImplementedException();
        }
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
