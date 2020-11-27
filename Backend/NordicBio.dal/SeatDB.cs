using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NordicBio.dal
{
    public class SeatDB
    {
        private string _constring;

        public SeatDB(string constring)
        {
            this._constring = constring;
        }

        public IEnumerable<Seat> GetAllSeats(int showingID)
        {
            var parameters = new { ShoginID = showingID };
            string sql = "SELECT * FROM Seats WHERE ShowingID = @ShowingID";
            List<Seat> res;

            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    res = connection.Query<Seat>(sql).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return res;
        }
    }
}
