using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Interfaces;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicBio.api.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowingController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ShowingController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #region - USER SECTION -
        // GET: api/<ShowingController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _unitOfWork.Showings.GetAll();
            if (data == null)
            {
                return NotFound("Sorry.. we found no showings");
            }
            return Ok(data);
        }

        // GET api/<ShowingController>/5
        [HttpGet("movie/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _unitOfWork.Showings.GetShowingsByID(id);
            if (data == null)
            {
                return NotFound("Sorry.. we found no showings for the specific movie");
            }
            return Ok(data);
        }

        #endregion
        #region - ADMIN SECTION -
        // TODO: admin create showings
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
        #endregion
    }
}
