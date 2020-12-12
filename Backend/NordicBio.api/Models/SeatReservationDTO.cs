using NordicBio.dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordicBio.model
{
    public class SeatReservationDTO
    {
        public List<SeatDTO> selectedseats { get; set; }
        public int ShowingID { get; set; }
        public string UUID { get; set; }
    }
}
