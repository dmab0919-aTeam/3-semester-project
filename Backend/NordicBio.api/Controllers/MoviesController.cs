using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region - USER SECTION -

        [HttpGet] // Get all
        public async Task<IActionResult> GetAsync()
        {
            var data = await _unitOfWork.Movies.GetAllAsync();
            List<MovieDTO> movieData = _mapper.Map<List<MovieDTO>>(data);

            if (movieData == null)
            {
                return NotFound("Sorry.. We found no movies");
            }

            return Ok(movieData);

        }

        [HttpGet("{id}")] // Get by id
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.Movies.GetByIDAsync(id);
            MovieDTO movieData = _mapper.Map<MovieDTO>(data);

            if (movieData == null)
            {
                return NotFound("Sorry.. We found no movie");
            }
            return Ok(movieData);
        }


        #endregion
        #region - ADMIN SECTION -

        [HttpPost] // Post
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostAsync(MovieDTO movieDTO)
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(MovieDTO movieDTO)
        {
            if (movieDTO != null)
            {
                Movie movie = _mapper.Map<Movie>(movieDTO);
                var data = await _unitOfWork.Movies.UpdateAsync(movie);
                return Ok(data);
            }

            return BadRequest("Sorry.. The movie was not updated");
        }

        [HttpDelete("{id}")] // Delete by id
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
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
