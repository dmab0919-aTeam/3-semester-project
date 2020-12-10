using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using NordicBio.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordicBio.api.Controllers
{

    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Post([FromBody] OrderDTO orderDTO)
        {
            int OrderID = await this._unitOfWork.Orders.AddAsync(this._mapper.Map<Order>(orderDTO));
            //ToDo Lave ordre
            List<int> skd = new List<int>();
            if (OrderID != 0)
            {
                foreach (var seat in orderDTO.Seats)
                {
                    seat.OrderID = OrderID;
                    int status = await this._unitOfWork.Seats.AddAsync(this._mapper.Map<Seat>(seat));
                    if (status == 0)
                    {
                        skd.Add(status);
                    }
                }
            }
            else
            {
                return BadRequest("Sorry.. Order was not created");
            }

            if (skd.Count > 0)
            {
                return BadRequest("Sorry.. Something went wrong");
            }

            return Ok("Lortet er gemt");
        }
    }
}