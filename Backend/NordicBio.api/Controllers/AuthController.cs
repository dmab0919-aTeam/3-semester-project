using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NordicBio.dal;
using NordicBio.model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NordicBio.api.Controllers
{
    class Token
    {
        public string Key { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private UserDB userDB;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
            string constring = _configuration.GetConnectionString("constring");
            userDB = new UserDB(constring);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(string email, string password)
        {
            User user = userDB.GetUser(email);
            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                Token t = new Token();
                t.Key = GenerateJSONWebToken(user.Email);
                var tokenString = JsonConvert.SerializeObject(t, Formatting.Indented);
                return Ok(tokenString);
            }
            else
            {
                return NotFound("User not found or wrong crenditials!");
            }

            Token t = new Token();
            t.Key = GenerateJSONWebToken();
            var tokenString = JsonConvert.SerializeObject(t, Formatting.Indented);
            return Ok(tokenString);
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register(
            string firstname,
            string lastname,
            string email,
            string phonenumber,
            string password
            )
        {

            User user = new User()
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                PhoneNumber = phonenumber,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                IsAdmin = false
            };

            if (userDB.CreateUser(user))
            {
                return Ok("User successfully created");
            }
            else
            {
                return BadRequest("User was not created");
            }
        }

        private string GenerateJSONWebToken(string email)
        {
            var claims = new[]
            {
                new Claim("email", email)
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
