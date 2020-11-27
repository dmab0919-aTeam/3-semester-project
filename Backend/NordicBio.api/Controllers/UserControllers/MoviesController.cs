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
            return Ok(data);
        }

        [HttpGet("{id}")] // Get by id
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Movies.GetByID(id);
            return Ok(data);
        }

        [HttpDelete("{id}")] // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.Movies.Delete(id);
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
