using Microsoft.IdentityModel.Tokens;
using NordicBio.model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NordicBio.api.Validation
{
    public class Token
    {
        public Token(UserDTO userDTO)
        {
            Key = GenerateJSONWebToken(userDTO);
        }

        public string Key { get; set; }
        public int UserID { get; set; }

        public string GenerateJSONWebToken(UserDTO userDTO)
        {
            var claims = new[]
            {
                new Claim("email", userDTO.Email),
                new Claim(ClaimTypes.Role, userDTO.UserRole)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "A-Team",
                audience: "A-Team",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials,
                claims: claims
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
