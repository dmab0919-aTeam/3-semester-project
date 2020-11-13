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
                try
                {
                    res = con.QuerySingleOrDefault<User>(sql, parameters);
                }
                catch (Exception e)
                {
                    throw new Exception("brugeren findes ikke");
                }
                
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
                } catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
                
            }

            return res;
        }
    }
}
