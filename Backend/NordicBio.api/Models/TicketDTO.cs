using System;

namespace NordicBio.model
{
    public class TicketDTO
    {
        public int SeatID { get; set; }
        public int TicketNumber { get; set; }
        public int ShowingID { get; set; }
        public int OrderID { get; set; }

        public TicketDTO(int ticketNumber)
        {
            TicketNumber = ticketNumber;
        }
    }
}
