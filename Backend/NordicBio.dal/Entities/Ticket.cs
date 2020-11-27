using System;

namespace NordicBio.model
{
    public class Ticket
    {
        public int TicketNumber { get; set; }
        public string Type { get; set; }
        public Showing MyShowing { get; set; }

        public Ticket(int ticketNumber, string type, Showing myShowing)
        {
            TicketNumber = ticketNumber;
            Type = type;
            MyShowing = myShowing;
        }
    }
}
