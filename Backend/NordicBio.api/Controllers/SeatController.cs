using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NordicBio.dal;
using NordicBio.model;
using System.Collections.Generic;

namespace NordicBio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SeatController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SeatDB _seatDB;

        // Construtor - Initializing connection string
        public SeatController(IConfiguration configuration)
        {
            _configuration = configuration;
            string constring = _configuration.GetConnectionString("constring");
            _seatDB = new SeatDB(constring);
        }

        // REQUEST - GET *
        [HttpGet]
        public IEnumerable<Seat> Get([FromBody] int showingID)
        {
            return _seatDB.GetAllSeats(showingID);
        }


    }
}
