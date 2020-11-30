using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using NordicBio.model;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.Seats.GetAll();
            return Ok(data);
        }

        // REQUEST - GET *
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var data = await _unitOfWork.Seats.GetAllById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SeatDTO seatmodel)
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
