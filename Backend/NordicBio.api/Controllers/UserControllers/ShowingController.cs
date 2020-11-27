using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Interfaces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicBio.api.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowingController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ShowingController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        // GET: api/<ShowingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ShowingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShowingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
