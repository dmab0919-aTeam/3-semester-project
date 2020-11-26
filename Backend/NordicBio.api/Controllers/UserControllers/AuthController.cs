using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NordicBio.api.Validation;
using NordicBio.dal;
using NordicBio.model;
using System;
using System.Collections.Generic;
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
        private UserDB _userDB;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
            string constring = _configuration.GetConnectionString("constring");
            _userDB = new UserDB(constring);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(string email, string password)
        {
            //Alle parametre bliver sendt med i en ValidateString klasse med den passende regex og en fejl besked
            List<ValidateString> validations = new List<ValidateString>()
            {
                new ValidateString(email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", "Email is not valid"),
                new ValidateString(password, "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$", "Password must contain at least 8 characters, one number and one letter")
            };

            //Parametrene bliver valideret, og hvis listen af fejl beskeder er over null, returneres et badrequest med alle beskederne
            if (InputValidator.StringInputValidation(validations).Count > 0)
            {
                return BadRequest(InputValidator.StringInputValidation(validations));
            }

            //Useren bliver fundet i DB
            User user = _userDB.GetUser(email);
            if (user != null)
            {
                //Userens password bliver hashet med salt, hvorefter det tjekkes om det stemmer overens med det der står i databasen.
                if (user.Password.Equals(Encrypt.HashPassword(user.Salt, password)))
                {
                    Token t = new Token();
                    t.Key = GenerateJSONWebToken(user.Email);
                    var tokenString = JsonConvert.SerializeObject(t, Formatting.Indented);
                    return Ok(tokenString);
                }
                else
                {
                    return NotFound("Email and password does not match");
                }
            }
            else
            {
                return NotFound("User not found");
            }
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
            //Alle parametre bliver sendt med i en ValidateString klasse med den passende regex og en fejl besked 
            List<ValidateString> validations = new List<ValidateString>()
            {
                new ValidateString(firstname,  "^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", "Firstname is not valid"),
                new ValidateString(lastname, "^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", "Lastname is not valid"),
                new ValidateString(email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", "Email is not valid"),
                new ValidateString(phonenumber, "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$", "Phonenumber is not valid"),
                new ValidateString(password, "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$", "Password must contain at least 8 characters, one number and one letter")
            };

            //Parametrene bliver valideret, og hvis listen af fejl beskeder er over null, returneres et badrequest med alle beskederne.
            if (InputValidator.StringInputValidation(validations).Count > 0)
            {
                return BadRequest(InputValidator.StringInputValidation(validations));
            }


            string salt = Encrypt.Salt();
            string hashedPassword = Encrypt.HashPassword(salt, password);

            User user = new User(firstname, lastname, email, phonenumber, salt, hashedPassword);


            if (_userDB.Create(user))
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
