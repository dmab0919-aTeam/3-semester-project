using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicBio.api.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #region - USER SECTION -
        [HttpGet] // Get all users
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.Users.GetAll();
            if (data == null)
            {
                return NotFound("Sorry.. We found no users");
            }
            return Ok(data);
        }

        [HttpGet("{id}")] // Get by id
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Users.GetByID(id);
            if (data == null)
            {
                return NotFound("Sorry.. We found no user by that id");
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO userDTO)
        {
            var salt = Encrypt.Salt();
            var hashedPassword = Encrypt.ComputeSha256Hash(userDTO.Password);

            User user = new User()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
                Salt = salt,
                Password = Encrypt.HashPassword(hashedPassword, salt),
                IsAdmin = false
            };

            var data = await _unitOfWork.Users.Add(user);
            return Ok(data);
        }
        #endregion

        #region - Admin Section -
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AdminPost([FromBody] UserDTO userDTO)
        {
            var salt = Encrypt.Salt();
            var hashedPassword = Encrypt.ComputeSha256Hash(userDTO.Password);

            User user = new User()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
                Salt = salt,
                Password = Encrypt.HashPassword(hashedPassword, salt),
                IsAdmin = userDTO.IsAdmin
            };

            var data = await _unitOfWork.Users.Add(user);
            return Ok(data);
        }
        #endregion
    }
}