using Dapper;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NordicBio.dal
{
    public class SeatDB : ICRUD<Seat>
    {
        private string _constring;

        public SeatDB(string constring)
        {
            this._constring = constring;
        }

        public bool Create(Seat t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Seat t)
        {
            throw new NotImplementedException();
        }

        public Seat Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seat> GetAll()
        {
            throw new NotImplementedException();
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

        public bool Update(Seat t)
        {
            throw new NotImplementedException();
        }
    }
}
