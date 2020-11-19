using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NordicBio.dal;
using NordicBio.model;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicBio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private MovieDB movieDB;

        public MoviesController(IConfiguration configuration)
        {
            _configuration = configuration;
            string constring = _configuration.GetConnectionString("constring");
            movieDB = new MovieDB(constring);

        }
        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return movieDB.GetAllMovies();
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return movieDB.GetMovie(id);
        }
    }
}
