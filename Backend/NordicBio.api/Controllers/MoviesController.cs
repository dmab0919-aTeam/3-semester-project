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
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MoviesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        #region - USER SECTION -

        [HttpGet] // Get all
        public async Task<IActionResult> Get()
        {
            var data = await _unitOfWork.Movies.GetAllAsync();
            List<MovieDTO> moviedata = _mapper.Map<List<MovieDTO>>(data);

            if (moviedata == null)
            {
                return NotFound("Sorry.. We found no movies");
            }

            return Ok(moviedata);

        }

        [HttpGet("{id}")] // Get by id
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Movies.GetByIDAsync(id);
            MovieDTO moviedata = _mapper.Map<MovieDTO>(data);

            if (moviedata == null)
            {
                return NotFound("Sorry.. We found no movie");
            }
            return Ok(moviedata);
        }


        #endregion
        #region - ADMIN SECTION -

        [HttpPost] // Post
        public async Task<IActionResult> Post(MovieDTO movieDTO)
        {
            if (movieDTO != null)
            {
                Movie movie = _mapper.Map<Movie>(movieDTO);
                var data = await _unitOfWork.Movies.AddAsync(movie);
                return Ok(data);
            }
            else
            {
                return BadRequest("Sorry.. The movie was not inserted");
            }
        }

        [HttpPut] // Update
        public async Task<IActionResult> Update(MovieDTO movieDTO)
        {
            if (movieDTO != null)
            {
                Movie movie = _mapper.Map<Movie>(movieDTO);
                var data = await _unitOfWork.Movies.UpdateAsync(movie);
                return Ok(data);
            }
            else
            {
                return BadRequest("Sorry.. The movie was not updated");
            }
        }

        [HttpDelete("{id}")] // Delete by id
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.Movies.DeleteAsync(id);

            if (data == 0)
            {
                return NotFound("Sorry.. We found no movie to delete with this id");
            }
            return Ok(data);
        }
        #endregion

    }
}
