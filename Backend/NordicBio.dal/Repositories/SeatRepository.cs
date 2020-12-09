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
            string sql = "INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID, [State], UserID) " +
                "VALUES (@Row, @Number, @ShowingID, @OrderID, @State, @UserID)";
            var parameters = new
            {
                Row = entity.Row,
                Number = entity.Number,
                ShowingID = entity.ShowingID,
                OrderID = entity.OrderID,
                State = "Reserved",
                UserID = entity.UserID,
            };

            using (SqlConnection con = new SqlConnection(_constring))
            {
                res = await con.ExecuteAsync(sql, parameters);
                return res;
            }
        }


        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteOldSeats(int id)
        {
            int res;
            string sql = "DELETE FROM Seats WHERE ReserveTime < DATEADD(mi,-10,GETDATE()) " +
                "AND ShowingID = @ShowingID " +
                "AND State = @Reserved";
            var parameters = new
            {
                ShowingID = id,
                Reserved = "Reserved"
            };

            using(var connection = new SqlConnection(_constring))
            {
                try
                {
                    res = await connection.ExecuteAsync(sql, parameters);
                    return res;
                }
                catch (Exception)
                {

                    throw;
                }
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

        public Task<Seat> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Seat entity)
        {
            throw new NotImplementedException();
        }
    }
}
