using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordicBio.api.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SeatController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SeatController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        #region - USER SECTION -
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.Seats.GetAll();
            List<SeatDTO> seatdata = _mapper.Map<List<SeatDTO>>(data);

            if (seatdata.Count == 0)
            {
                return NotFound("Sorry.. We found no seats");
            }
            return Ok(seatdata);
        }

        // REQUEST - GET *
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var data = await _unitOfWork.Seats.GetAllById(id);
            List<SeatDTO> seatdata = _mapper.Map<List<SeatDTO>>(data);

            if (seatdata.Count == 0)
            {
                return NotFound("Sorry.. We found no seats");
            }
            return Ok(seatdata);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SeatDTO seatDTO)
        {
            Seat seat = _mapper.Map<Seat>(seatDTO);


            var data = await _unitOfWork.Seats.Add(seat);
            return Ok(data);
        }
        #endregion
        #region - ADMIN SECTION -

        #endregion


    }
}
