using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicBio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        #region - USER SECTION -

        #endregion

        #region - Admin Section -

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string email)
        {
            var data = await _unitOfWork.Users.DeleteAsync(email);
            if (data > 0)
            {
                return Ok("User was deleted");
            }
            return BadRequest("Sorry.. User was not deleted");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminPost([FromBody] UserDTO userDTO)
        {
            userDTO.Salt = Encrypt.Salt();
            userDTO.Password = Encrypt.HashPassword(userDTO.Salt, userDTO.Password);

            User userdata = _mapper.Map<User>(userDTO);
            var data = await _unitOfWork.Users.AddAsync(userdata);
            if (data == 0)
            {
                return BadRequest("Sorry.. User was not created");
            }
            return Ok("Admin succesfully created");
        }

        [HttpGet] // Get all users
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.Users.GetAllAsync();
            List<UserDTO> userdata = _mapper.Map<List<UserDTO>>(data);
            if (userdata == null)
            {
                return NotFound("Sorry.. We found no users");
            }
            return Ok(userdata);
        }

        [HttpGet("{id}")] // Get by id
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Users.GetByIDAsync(id);
            UserDTO userdata = _mapper.Map<UserDTO>(data);
            if (userdata == null)
            {
                return NotFound("Sorry.. We found no user by that id");
            }
            return Ok(userdata);
        }
        #endregion
    }
}