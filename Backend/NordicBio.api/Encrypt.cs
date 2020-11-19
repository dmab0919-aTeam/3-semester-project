using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NordicBio.api
{
    public static class Encrypt
    {
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   

            using (SHA256 sha256Hash = SHA256.Create())

            {   // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)

                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static string HashPassword(string salt, string password)
        {
            string letter4 = password.Substring(4, 1);
            int length = password.Length;

            string saltedPassword = password + letter4 + length + salt;

            return ComputeSha256Hash(saltedPassword);
        }

        public static string Salt()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 20);
        }
    }
}
