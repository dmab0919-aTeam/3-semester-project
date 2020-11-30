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

    public class SeatController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeatController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // REQUEST - GET *
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int showingID)
        {
            var data = await _unitOfWork.Seats.GetAllById(showingID);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SeatModel seatmodel)
        {
            Seat seat = new Seat()
            {
                Number = seatmodel.Number,
                Row = seatmodel.Row,
                ShowingID = seatmodel.ShowingID
            };
            
            var data = await _unitOfWork.Seats.Add(seat);
            return Ok(data);
        }


    }
}
