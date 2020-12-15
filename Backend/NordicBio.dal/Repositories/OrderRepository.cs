using System;
using Dapper;
using Microsoft.Extensions.Configuration;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NordicBio.dal
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _constring;
        public OrderRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._constring = _configuration.GetConnectionString("constring");
        }

        public async Task<int> AddAsync(Order entity)
        {
            int res;
            string sql = "INSERT INTO [Orders] " +
                "(TotalPrice, UserID, ShowingID) " +
                "OUTPUT INSERTED.Id VALUES " +
                "(@TotalPrice, @UserID, @ShowingID)";
            var parameters = new
            {
                TotalPrice = entity.TotalPrice,
                UserID = entity.UserID,
                ShowingID = entity.ShowingID
            };

            using (SqlConnection con = new SqlConnection(_constring))
            {
                res = await con.QuerySingleOrDefaultAsync<int>(sql, parameters);
                return res;
            }
        }

        // NOT IMPLEMENTET

        public Task<int> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(Order entity)
        {
            throw new System.NotImplementedException();
        }
        public async Task<Order> GetByIDAsync(int id)
        {
            var sql = "SELECT * FROM [Orders] WHERE [id] = @Id";
            var parameters = new { Id = id };
            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.QuerySingleOrDefaultAsync<Order>(sql, parameters);
                    return result;
                }
                catch (Exception)
                {
                    throw new Exception("Showing Findes ikke");
                }
            }
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}