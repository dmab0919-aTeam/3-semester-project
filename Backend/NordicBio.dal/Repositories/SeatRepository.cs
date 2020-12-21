using Dapper;
using Microsoft.Extensions.Configuration;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace NordicBio.dal
{
    public class SeatRepository : ISeatRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _constring;

        public SeatRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _constring = _configuration.GetConnectionString("constring");
        }
        public async Task<int> AddAsync(Seat entity)
        {
            const string sql = "INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, [State]) " +
                               "VALUES (@Row, @Number, @ShowingID, @State)";
            var parameters = new
            {
                Row = entity.Row,
                Number = entity.Number,
                ShowingID = entity.ShowingID,
                State = "Reserved"
            };
            using (TransactionScope ts = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(_constring))
                {
                    var res = await con.ExecuteAsync(sql, parameters);
                    return res;
                }
            }

        }

        public async Task<List<int>> AddSeatAsync(List<Seat> entityList)
        {
            List<int> res = new List<int>();
            using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                using (SqlConnection con = new SqlConnection(_constring))
                {
                    foreach (var seat in entityList)
                    {
                        const string sql = "INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, [State], UUID) " +
                                           "VALUES (@Row, @Number, @ShowingID, @State, @UUID)";
                        var parameters = new
                        {
                            Row = seat.Row,
                            Number = seat.Number,
                            ShowingID = seat.ShowingID,
                            State = "Reserved",
                            UUID = seat.UUID
                        };
                        res.Add(await con.ExecuteAsync(sql, parameters));
                    }
                }
                ts.Complete();
            }
            return res;
        }

        public async Task<int> BuySeatAsync(Seat entity)
        {
            const string sql = "IF EXISTS (SELECT * FROM Seats WHERE [Row] = @Row AND [Number] = @Number AND ShowingID = @ShowingID AND [State] = 'Reserved' AND UUID = @UUID) " +
                               "BEGIN " +
                               "UPDATE Seats SET [State] = 'Bought', OrderID = @OrderID " +
                               "WHERE [Row] = @Row AND [Number] = @Number AND ShowingID = @ShowingID AND [State] = 'Reserved' AND UUID = @UUID " +
                               "END " +
                               "ELSE " +
                               "BEGIN " +
                               "IF EXISTS (SELECT * FROM Seats WHERE [Row] = @Row AND [Number] = @Number AND ShowingID = @ShowingID AND [State] = 'Reserved') " +
                               "BEGIN " +
                               "PRINT '' " +
                               "END " +
                               "ELSE " +
                               "BEGIN " +
                               "INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID, [State], UUID) VALUES (@Row, @Number, @ShowingID, @OrderID, 'Bought', @UUID) " +
                               "END " +
                               "END";
            var parameters = new
            {
                OrderID = entity.OrderID,
                Row = entity.Row,
                Number = entity.Number,
                ShowingID = entity.ShowingID,
                UUID = entity.UUID
            };

            using (SqlConnection con = new SqlConnection(_constring))
            {
                var res = await con.ExecuteAsync(sql, parameters);
                return res;
            }
        }

        public async Task<int> DeleteOldSeatsAsync(int id)
        {
            const string sql = "DELETE FROM Seats WHERE ReserveTime < DATEADD(mi,-10,GETDATE()) " +
                               "AND ShowingID = @ShowingID " +
                               "AND State = @Reserved";
            var parameters = new
            {
                ShowingID = id,
                Reserved = "Reserved"
            };

            using (var connection = new SqlConnection(_constring))
            {
                var res = await connection.ExecuteAsync(sql, parameters);
                return res;
            }
        }
        public async Task<IEnumerable<Seat>> GetAllAsync()
        {
            const string sql = "SELECT * FROM [Seats]";

            using (var connection = new SqlConnection(_constring))
            {
                var result = await connection.QueryAsync<Seat>(sql);
                return result.ToList();
            }
        }
        public async Task<IEnumerable<Seat>> GetAllByIdAsync(int id)
        {
            const string sql = "SELECT * FROM [Seats] WHERE [ShowingID] = @Id";
            var parameters = new { Id = id };

            using (var connection = new SqlConnection(_constring))
            {
                var result = await connection.QueryAsync<Seat>(sql, parameters);
                return result;
            }
        }
        
        public async Task<IEnumerable<Seat>> GetAllByOrderIdAsync(int id)
        {
            const string sql = "SELECT * FROM [Seats] WHERE [OrderID] = @Id";
            var parameters = new { Id = id };

            using (var connection = new SqlConnection(_constring))
            {
                var result = await connection.QueryAsync<Seat>(sql, parameters);
                return result.ToList();
            }
        }

        // NOT IMPLEMENTET

        public Task<Seat> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Seat entity)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
