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
            string sql = "INSERT INTO Seats (Row, Number, ShowingID) VALUES (@Row, @Number, @ShowingID)";
            var parameters = new
            {
                Row = entity.Row,
                Number = entity.Number,
                ShowingID = entity.ShowingID
            };

            using(SqlConnection con = new SqlConnection(_constring))
            {
                res = await con.ExecuteAsync(sql, parameters);
                return res;
            }
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Seat>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Seat>> GetAllById(int showingID)
        {
            string sql = "SELECT * FROM Seats WHERE ShowingID = @ShowingID";
            var parameters = new { ShowingID = showingID };

            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.QueryAsync<Seat>(sql,parameters);
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
