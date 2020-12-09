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

        public Task<Order> GetByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Add(Order entity)
        {
            int res;
            string sql = "INSERT INTO Orders (TotalPrice, UserID, ShowingID) OUTPUT INSERTED.Id VALUES (@TotalPrice, @UserID, @ShowingID)";
            var parameters = new
            {
                TotalPrice = entity.TotalPrice,
                UserID = entity.UserID,
                ShowingID = entity.ShowingID
            };

            using (SqlConnection con = new SqlConnection(_constring))
            {
                res = await con.ExecuteAsync(sql, parameters);
                return res;
            }
        }

        // NOT IMPLEMENTET

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Order entity)
        {
            throw new System.NotImplementedException();
        }
    }
}