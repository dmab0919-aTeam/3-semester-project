using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicBio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet] // Get all
        public async Task<IActionResult> Get()
        {
            var data = await _unitOfWork.Movies.GetAll();

            if (data == null)
            {
                return NotFound("Sorry.. We found no movies");
            }
            return Ok(data);
        }

        [HttpGet("{id}")] // Get by id
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Movies.GetByID(id);

            if (data == null)
            {
                return NotFound("Sorry.. We found no movie");
            }
            return Ok(data);
        }

        [HttpDelete("{id}")] // Delete by id
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.Movies.Delete(id);

            if (data == 0)
            {
                return NotFound("Sorry.. We found no movie to delete with this id");
            }
            return Ok(data);
        }
        [HttpPut] // Update
        public async Task<IActionResult> Update(Movie movie)
        {
            var data = await _unitOfWork.Movies.Update(movie);
            return Ok(data);
        }
    }
}
