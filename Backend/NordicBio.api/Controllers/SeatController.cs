using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System.Threading.Tasks;

namespace NordicBio.api.Controllers.UserControllers
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

        #region - USER SECTION -
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.Seats.GetAll();

            if (data == null)
            {
                return NotFound("Sorry.. We found no seats");
            }
            return Ok(data);
        }

        // REQUEST - GET *
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var data = await _unitOfWork.Seats.GetAllById(id);

            if (data == null)
            {
                return NotFound("Sorry.. We found no seats");
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SeatDTO seatDTO)
        {
            Seat seat = new Seat()
            {
                Number = seatDTO.Number,
                Row = seatDTO.Row,
                ShowingID = seatDTO.ShowingID
            };

            var data = await _unitOfWork.Seats.Add(seat);
            return Ok(data);
        }
        #endregion
        #region - ADMIN SECTION -

        #endregion


    }
}
