using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System.Collections.Generic;

namespace NordicBio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SeatController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeatController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // REQUEST - GET *
        [HttpGet]
        public IEnumerable<SeatModel> Get([FromBody] int showingID)
        {
            //return _seatDB.GetAllSeats(showingID);
            return null;
        }


    }
}
