﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NordicBio.dal;
using NordicBio.model;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicBio.api.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AdminShowingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private ShowingDB _showingDB;
        public AdminShowingController(IConfiguration configuration)
        {
            _configuration = configuration;
            string constring = _configuration.GetConnectionString("constring");
            _showingDB = new ShowingDB(constring);
        }

        // GET: api/<ShowingController>
        [HttpGet]
        public IEnumerable<Showing> GetAllShowings()
        {
            return _showingDB.GetAll();
        }

        // GET api/<ShowingController>/5
        [HttpGet("movie/{id}")]
        public IEnumerable<Showing> Get(int id)
        {
            return _showingDB.getShowingsByID(id);
        }

        // POST api/<ShowingController>
        [HttpPost]
        public ActionResult Post([FromBody] Showing showing)
        {

            return Ok(_showingDB.Create(showing));

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