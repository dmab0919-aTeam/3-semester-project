﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NordicBio.api.Validation;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordicBio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] Login login)
        {
            string email = login.email;
            string password = login.password;

            List<ValidateString> validations = UserValidation.ValidateLogin(email, password);

            //Parametrene bliver valideret, og hvis listen af fejl beskeder er over null, returneres et badrequest med alle beskederne
            if (InputValidator.StringInputValidation(validations).Count > 0)
            {
                return BadRequest(InputValidator.StringInputValidation(validations));
            }

            //Useren bliver fundet i DB, og mappet til userDTO
            var data = await _unitOfWork.Users.GetByEmailAsync(email);
            UserDTO user = _mapper.Map<UserDTO>(data);

            if (user != null)
            {
                //Userens password bliver hashet med salt, hvorefter det tjekkes om det stemmer overens med det der står i databasen.
                if (user.Password.Equals(Encrypt.HashPassword(user.Salt, password)))
                {
                    var tokenString = JsonConvert.SerializeObject(new Token(user), Formatting.Indented);
                    return Ok(tokenString);
                }

                return BadRequest("Email and password does not match");
            }

            return BadRequest("User not found");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserDTO userDTO)
        {
            List<ValidateString> validations = UserValidation.ValidateUser(userDTO);

            //User bliver valideret, og hvis listen af fejl beskeder er over 0, returneres et badrequest med alle fejl beskederne.
            if (InputValidator.StringInputValidation(validations).Count > 0)
            {
                return BadRequest(InputValidator.StringInputValidation(validations));
            }

            userDTO.UserRole = "User";
            userDTO.Salt = Encrypt.Salt();
            userDTO.Password = Encrypt.HashPassword(userDTO.Salt, userDTO.Password);

            var createRequest = await _unitOfWork.Users.AddAsync(this._mapper.Map<User>(userDTO));

            if (createRequest > 0)
            {
                return Ok("User successfully created");
            }

            return BadRequest("User was not created");
        }
    }
}