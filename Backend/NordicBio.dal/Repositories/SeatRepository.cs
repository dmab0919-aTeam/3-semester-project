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

        public Task<int> Add(Seat entity)
        {
            throw new NotImplementedException();
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
            var parameters = new { ShoginID = showingID };

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
