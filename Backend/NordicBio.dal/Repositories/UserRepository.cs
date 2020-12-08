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

        public Task<User> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Add(User entity)
        {
            var parameters = new
            {
                Firstname = entity.FirstName,
                Lastname = entity.LastName,
                Email = entity.Email,
                Phonenumber = entity.PhoneNumber,
                Salt = entity.Salt,
                Password = entity.Password,
                UserRole = entity.UserRole
            };
            var sql = "Insert into Users (FirstName, LastName, Email, PhoneNumber, Salt, Password, UserRole) Values (@Firstname, @Lastname, @Email, @Phonenumber, @Salt, @Password, @UserRole)";

            using (SqlConnection con = new SqlConnection(_constring))
            {
                try
                {
                    var res = await con.ExecuteAsync(sql, parameters);
                    return res;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
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

        public async Task<int> Delete(string email)
        {
            var sql = "DELETE FROM Users WHERE Email = @UserEmail";
            var parameters = new { UserEmail = email };

            using (SqlConnection connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.ExecuteAsync(sql, parameters);
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
