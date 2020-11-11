using Dapper;
using NordicBio.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NordicBio.dal
{
    public class UserDB
    {
        private string _constring;
        public UserDB(string constring)
        {
            _constring = constring;
        }

        public User GetUser(string email)
        {
            User res;

            var parameters = new { UserEmail = email};
            var sql = "SELECT * FROM Users WHERE Email = @UserEmail";
            using (SqlConnection con = new SqlConnection(_constring))
            {
                res = con.QuerySingleOrDefault<User>(sql, parameters);
            }

            return res;
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
                Password = user.Password,
                Isadmin = user.IsAdmin
            };
            var sql = "Insert into Users (FirstName, LastName, Email, PhoneNumber, Password, IsAdmin) Values (@Firstname, @Lastname, @Email, @Phonenumber, @Password, @Isadmin)";

            using (SqlConnection con = new SqlConnection(_constring))
            {
                res = con.QuerySingleOrDefault(sql, parameters);
            }

            return res;
        }
    }
}
