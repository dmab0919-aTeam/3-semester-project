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
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _constring;
        public UserRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._constring = _configuration.GetConnectionString("constring");
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var sql = "SELECT [FirstName], [LastName] ,[Email], [PhoneNumber], [UserRole], [Password] FROM [Users]" +
                "ORDER BY [id]";

            using (var connection = new SqlConnection(_constring))
            {
                try
                {
                    var result = await connection.QueryAsync<User>(sql);
                    return result.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public async Task<int> AddAsync(User entity)
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
            var sql = "Insert into [Users] " +
                "(FirstName, LastName, Email, PhoneNumber, Salt, Password, UserRole) " +
                "Values " +
                "(@Firstname, @Lastname, @Email, @Phonenumber, @Salt, @Password, @UserRole)";

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
        public async Task<User> GetByEmailAsync(string email)
        {
            var sql = "SELECT * FROM [Users] WHERE [Email] = @UserEmail";
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
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM [Users] WHERE [id] = @userid";
            var parameters = new { userid = id };

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

        // NOT IMPLEMENTET

        public Task<User> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<int> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
