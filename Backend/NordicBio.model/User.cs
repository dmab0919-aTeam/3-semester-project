using System;
using System.Collections;

namespace NordicBio.model
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        /*public User(string firstName, string lastName, string email, string phoneNumber, string password, bool isAdmin)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            IsAdmin = isAdmin;
        }*/

        /*public void AddOrder(Order newOrder) 
        {
            orders.Add(newOrder);
        }*/
    }
}
