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
    public class ShowingController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ShowingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region - USER SECTION -

        // GET api/<ShowingController>/5
        [HttpGet("movie/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.Showings.GetShowingsByIDAsync(id);
            List<ShowingDTO> showingdata = _mapper.Map<List<ShowingDTO>>(data);
            if (showingdata == null)
            {
                return NotFound("Sorry.. we found no showings for the specific movie");
            }
            return Ok(showingdata);
        }

        #endregion

        #region - ADMIN SECTION -

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostAsync([FromBody] ShowingDTO showingDTO)
        {
            if (showingDTO != null)
            {
                Showing showing = _mapper.Map<Showing>(showingDTO);
                var data = await _unitOfWork.Showings.AddAsync(showing);
                return Ok(data);
            }

            return BadRequest("Sorry.. The movie was not updated");
        }

        // GET: api/<ShowingController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _unitOfWork.Showings.GetAllAsync();
            List<ShowingDTO> showingData = _mapper.Map<List<ShowingDTO>>(data);
            if (showingData == null)
            {
                return NotFound("Sorry.. we found no showings");
            }
            return Ok(showingData);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _unitOfWork.Showings.DeleteAsync(id);
            if (data > 0)
            {
                return Ok("Showing was deleted");
            }
            return BadRequest("Sorry.. Showing was not deleted");
        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync([FromBody] ShowingDTO showingDTO)
        {
            if (showingDTO != null)
            {
                Showing showing = _mapper.Map<Showing>(showingDTO);
                var data = await _unitOfWork.Showings.UpdateAsync(showing);
                return Ok(data);
            }

            return BadRequest("Sorry.. The movie was not updated");
        }
        #endregion
    }
}
