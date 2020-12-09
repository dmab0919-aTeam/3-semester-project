using AutoMapper;
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
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        #region - USER SECTION -
        // GET: api/<ShowingController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _unitOfWork.Showings.GetAll();
            List<ShowingDTO> showingdata = _mapper.Map<List<ShowingDTO>>(data);
            if (showingdata == null)
            {
                return NotFound("Sorry.. we found no showings");
            }
            return Ok(showingdata);
        }

        // GET api/<ShowingController>/5
        [HttpGet("movie/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _unitOfWork.Showings.GetShowingsByID(id);
            List<ShowingDTO> showingdata = _mapper.Map<List<ShowingDTO>>(data);
            if (showingdata == null)
            {
                return NotFound("Sorry.. we found no showings for the specific movie");
            }
            return Ok(showingdata);
        }

        #endregion
        #region - ADMIN SECTION -
        // TODO: admin create showings
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShowingDTO showingDTO)
        {
            if (showingDTO != null)
            {
                Showing showing = _mapper.Map<Showing>(showingDTO);
                var data = await _unitOfWork.Showings.Add(showing);
                return Ok(data);
            }
            else
            {
                return BadRequest("Sorry.. The movie was not updated");
            }
        }
        #endregion
    }
}
