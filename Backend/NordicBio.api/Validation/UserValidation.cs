using NordicBio.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordicBio.api.Validation
{
    public static class UserValidation
    {
        public static List<ValidateString> ValidateUser(UserDTO userDTO)
        {
            List<ValidateString> validations = new List<ValidateString>()
            {
                new ValidateString(userDTO.FirstName,  "^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", "Firstname is not valid"),
                new ValidateString(userDTO.LastName, "^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", "Lastname is not valid"),
                new ValidateString(userDTO.Email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", "Email is not valid"),
                new ValidateString(userDTO.PhoneNumber, "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$", "Phonenumber is not valid"),
                new ValidateString(userDTO.Password, "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$", "Password must contain at least 8 characters, one number and one letter")
            };

            return validations;
        }

        public static List<ValidateString> ValidateLogin(string email, string password)
        {
            List<ValidateString> validations = new List<ValidateString>()
            {
                new ValidateString(email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", "Email is not valid"),
                new ValidateString(password, "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$", "Password must contain at least 8 characters, one number and one letter")
            };

            return validations;
        }
    }
}