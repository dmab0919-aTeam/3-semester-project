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
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region - USER SECTION -
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _unitOfWork.Seats.GetAllAsync();
            List<SeatDTO> seatData = _mapper.Map<List<SeatDTO>>(data);

            if (seatData.Count == 0)
            {
                return NotFound("Sorry.. We found no seats");
            }
            
            return Ok(seatData);
        }

        // REQUEST - GET *
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDAsync(int id)
        {
            //delete reserved seats der er ældre end 10 minuter.
            await _unitOfWork.Seats.DeleteOldSeatsAsync(id);

            var data = await _unitOfWork.Seats.GetAllByIdAsync(id);
            List<SeatDTO> seatData = _mapper.Map<List<SeatDTO>>(data);

            if (seatData.Count == 0)
            {
                return Ok("no seats");
            }
            return Ok(seatData);
        }
        
        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetOrderIdAsync(int id)
        {
            var data = await _unitOfWork.Seats.GetAllByOrderIdAsync(id);
            List<SeatDTO> seatData = _mapper.Map<List<SeatDTO>>(data);

            if (seatData.Count == 0)
            {
                return Ok("no seats");
            }
            return Ok(seatData);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SeatReservationDTO seatReservationDTO)
        {
            try
            {
                if (seatReservationDTO.SelectedSeats != null)
                {
                    if (seatReservationDTO.SelectedSeats.Count > 0)
                    {
                        foreach (var seatDTO in seatReservationDTO.SelectedSeats)
                        {
                            seatDTO.ShowingID = seatReservationDTO.ShowingID;
                            seatDTO.UUID = seatReservationDTO.UUID;
                        }
                        await _unitOfWork.Seats.AddSeatAsync(this._mapper.Map<List<Seat>>(seatReservationDTO.SelectedSeats));
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
    }
}
