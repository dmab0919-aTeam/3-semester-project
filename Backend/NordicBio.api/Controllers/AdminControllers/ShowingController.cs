using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NordicBio.dal;
using NordicBio.model;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicBio.api.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ShowingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private ShowingDB _showingDB;
        public ShowingController(IConfiguration configuration)
        {
            _configuration = configuration;
            string constring = _configuration.GetConnectionString("constring");
            _showingDB = new ShowingDB(constring);
        }


        // GET: api/<ShowingController>
        [HttpGet]
        public IEnumerable<Showing> GetAllShowings()
        {
            return _showingDB.getAllShowings();
        }





        // GET api/<ShowingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }




        // POST api/<ShowingController>
        [HttpPost]
        public ActionResult Post([FromBody] Showing showing)
        {

            return Ok(_showingDB.CreateShowing(showing));

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
