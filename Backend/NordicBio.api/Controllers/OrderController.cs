﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NordicBio.dal.Entities;
using NordicBio.dal.Interfaces;
using NordicBio.model;

namespace NordicBio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrderDTO orderDTO)
        {
            var data = await _unitOfWork.Showings.GetByIDAsync(orderDTO.ShowingID);
            ShowingDTO showing = _mapper.Map<ShowingDTO>(data);

            orderDTO.TotalPrice = showing.Price * orderDTO.Seats.Count;
        
            int orderId = await _unitOfWork.Orders.AddAsync(_mapper.Map<Order>(orderDTO));
            List<int> skd = new List<int>();
            if (orderId != 0)
            {
                foreach (var seat in orderDTO.Seats)
                {
                    seat.ShowingID = orderDTO.ShowingID;
                    seat.OrderID = orderId;
                    seat.UUID = orderDTO.UUID;
                    int status = await _unitOfWork.Seats.BuySeatAsync(this._mapper.Map<Seat>(seat));
                    if (status == 0 || status == -1)
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

            return Ok(orderId);
        }
        
        [HttpGet("{id}")] // Get by id
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.Orders.GetByIDAsync(id);
            OrderDTO order = _mapper.Map<OrderDTO>(data);

            if (order == null)
            {
                return BadRequest("Sorry.. We found no order");
            }
            
            return Ok(order);
        }
    }
}