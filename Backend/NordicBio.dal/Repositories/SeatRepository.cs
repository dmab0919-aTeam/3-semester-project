﻿using Dapper;
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
        public async Task<int> AddAsync(Seat entity)
        {
            int res;
            string sql = "INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, [State]) " +
                "VALUES (@Row, @Number, @ShowingID, @State)";
            var parameters = new
            {
                Row = entity.Row,
                Number = entity.Number,
                ShowingID = entity.ShowingID,
                State = "Reserved"
            };

            using (SqlConnection con = new SqlConnection(_constring))
            {
                try
                {
                    res = await con.ExecuteAsync(sql, parameters);
                    return res;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<int> BuySeatAsync(Seat entity)
        {
            int res;
            string sql = "IF EXISTS (SELECT * FROM Seats WHERE [Row] = @Row AND [Number] = @Number AND ShowingID = @ShowingID AND [State] = 'Reserved') " +
                "BEGIN " +
                "UPDATE Seats SET [State] = 'Bought', OrderID = @OrderID " +
                "WHERE [Row] = @Row AND [Number] = @Number AND ShowingID = @ShowingID AND [State] = 'Reserved' " +
                "END " +
                "ELSE " +
                "BEGIN " +
                "INSERT INTO[dbo].[Seats] (Row, Number, ShowingID, OrderID, [State]) VALUES (@Row, @Number, @ShowingID, @OrderID, 'Bought') " +
                "END";
            var parameters = new
            {
                OrderID = entity.OrderID,
                Row = entity.Row,
                Number = entity.Number,
                ShowingID = entity.ShowingID
            };

            using(SqlConnection con = new SqlConnection(_constring))
            {
                try
                {
                    res = await con.ExecuteAsync(sql, parameters);
                    return res;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<int> DeleteOldSeatsAsync(int id)
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

            using (var connection = new SqlConnection(_constring))
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
        public async Task<IEnumerable<Seat>> GetAllAsync()
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
        public async Task<IEnumerable<Seat>> GetAllByIdAsync(int id)
        {
            var sql = "SELECT * FROM [Seats] WHERE [ShowingID] = @Id";
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
