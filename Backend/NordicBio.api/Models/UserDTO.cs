using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace NordicBio.model
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string Salt { get; set; }
        public bool IsAdmin { get; set; }

        public UserDTO()
        {

        }

        public UserDTO(string firstName, string lastName, string email, string phoneNumber,string salt, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Salt = salt;
            Password = password;
        }
        /*public void AddOrder(Order newOrder) 
        {
            orders.Add(newOrder);
        }*/
    }
}
