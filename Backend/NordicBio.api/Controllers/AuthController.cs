using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

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
        public AuthController()
        {

        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
           if ((username != "Secret") || (password != "Secret"))
            {
                return NotFound("User not found or wrong crenditials!");
            }

            Token t = new Token();
            t.Key = GenerateJSONWebToken();
            var tokenString = JsonConvert.SerializeObject(t, Formatting.Indented);
            return Ok(tokenString);
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://www.yogihosting.com",
                audience: "https://www.yogihosting.com",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
