using System;
using System.Collections;
using System.Collections.Generic;

namespace NordicBio.model
{
    public class OrderDTO
    {
        public int ShowingID { get; set; }
        public int UserID { get; set; }
        public double TotalPrice { get; set; }
        public List<SeatDTO> Seats { get; set; }
        public string UUID { get; set; }
        public OrderDTO()
        {
            
        }
    }
}
