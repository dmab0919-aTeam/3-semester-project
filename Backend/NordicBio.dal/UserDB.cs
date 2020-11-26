using Dapper;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NordicBio.dal
{
    public class UserDB : ICRUD<User>
    {
        private string _constring;
        public UserDB(string constring)
        {
            _constring = constring;
        }

        public User GetUser(string email)
        {
            User res;

            var parameters = new { UserEmail = email };
            var sql = "SELECT * FROM Users WHERE Email = @UserEmail";
            using (SqlConnection con = new SqlConnection(_constring))
            {
                try
                {
                    res = con.QuerySingleOrDefault<User>(sql, parameters);
                }
                catch (Exception)
                {
                    throw new Exception("brugeren findes ikke");
                }

            }

            return res;
        }

        public bool Create(User t)
        {
            bool res;
            var parameters = new
            {
                Firstname = t.FirstName,
                Lastname = t.LastName,
                Email = t.Email,
                Phonenumber = t.PhoneNumber,
                Salt = t.Salt,
                Password = t.Password,
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

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(User t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User t)
        {
            throw new NotImplementedException();
        }
    }
}
