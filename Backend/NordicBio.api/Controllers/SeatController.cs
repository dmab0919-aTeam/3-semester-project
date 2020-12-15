using System;
using AutoMapper;
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
            var data = await _unitOfWork.Seats.GetAllAsync();
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
            //delete reserved seats der er ældre end 10 minuter.
            await _unitOfWork.Seats.DeleteOldSeatsAsync(id);

            var data = await _unitOfWork.Seats.GetAllByIdAsync(id);
            List<SeatDTO> seatdata = _mapper.Map<List<SeatDTO>>(data);

            if (seatdata.Count == 0)
            {
                return Ok("no seats");
            }
            return Ok(seatdata);
        }
        
        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetOrderid(int id)
        {
            var data = await _unitOfWork.Seats.GetAllByOrderIdAsync(id);
            List<SeatDTO> seatdata = _mapper.Map<List<SeatDTO>>(data);

            if (seatdata.Count == 0)
            {
                return Ok("no seats");
            }
            return Ok(seatdata);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SeatReservationDTO seatReservationDTO)
        {
            try
            {
                if (seatReservationDTO.selectedseats != null)
                {
                    if (seatReservationDTO.selectedseats.Count > 0)
                    {
                        foreach (var seatDTO in seatReservationDTO.selectedseats)
                        {
                            seatDTO.ShowingID = seatReservationDTO.ShowingID;
                            seatDTO.UUID = seatReservationDTO.UUID;
                        }
                        await _unitOfWork.Seats.AddSeatAsync(this._mapper.Map<List<Seat>>(seatReservationDTO.selectedseats));
                    }
                }
                return Ok("Reservation was made");
            }
            catch (Exception)
            { 
                return BadRequest("Sorry.. Seats could not be reserverd");
            }
            
        }
        #endregion
        #region - ADMIN SECTION -

        #endregion
    }
}
