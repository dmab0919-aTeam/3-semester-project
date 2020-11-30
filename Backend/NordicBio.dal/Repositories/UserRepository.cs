using Dapper;
using Microsoft.Extensions.Configuration;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NordicBio.dal
{
    public class UserRepository : IUserRepository, IRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _constring;

        public UserRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._constring = _configuration.GetConnectionString("constring");
        }
        public string FetchConnection()
        {
            return _constring;
        }

        public bool CreateUser(User user)
        {
            bool res;
            var parameters = new
            {
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                Phonenumber = user.PhoneNumber,
                Salt = user.Salt,
                Password = user.Password,
                Isadmin = false
            };
            var sql = "Insert into Users (FirstName, LastName, Email, PhoneNumber, Salt, Password, IsAdmin) Values (@Firstname, @Lastname, @Email, @Phonenumber, @Salt, @Password, @Isadmin)";

            using (SqlConnection con = new SqlConnection(_constring))
            {
                try
                {
                    con.QuerySingleOrDefault(sql, parameters);
                    res = true;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }

            return res;
        }

        public Task<User> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmail(string email)
        {
            var sql = "SELECT * FROM Users WHERE Email = @UserEmail";
            var parameters = new { UserEmail = email };

            using (SqlConnection connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.QuerySingleOrDefaultAsync<User>(sql, parameters);
                    return result;
                }
                catch (Exception)
                {
                    throw new Exception("brugeren findes ikke");
                }

            }
        }
    }
}
