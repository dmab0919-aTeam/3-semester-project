using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Interfaces;
using System.Collections.Generic;
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


        // GET: api/<ShowingController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _unitOfWork.Showings.GetAll();
            if(data == null)
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
            if(data == null)
            {
                return NotFound("Sorry.. we found no showings for the specific movie");
            }
            return Ok(data);
        }


        // TODO: admin create showings
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShowingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShowingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
