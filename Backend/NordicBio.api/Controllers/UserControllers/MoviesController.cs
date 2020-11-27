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

        private MovieDB _movieDB;

        public MoviesController(IConfiguration configuration)
        {
            _configuration = configuration;
            string constring = _configuration.GetConnectionString("constring");
            _movieDB = new MovieDB(constring);
        }
        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<MovieModel> Get()
        {
            return _movieDB.GetAllMovies();
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public MovieModel Get(int id)
        {
            return _movieDB.GetMovie(id);
        }
    }
}
