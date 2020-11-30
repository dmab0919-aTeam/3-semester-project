using System;

namespace NordicBio.model
{
    public class TicketModel
    {
        public int TicketNumber { get; set; }
        public string Type { get; set; }
        public ShowingModel MyShowing { get; set; }

        public TicketModel(int ticketNumber, string type, ShowingModel myShowing)
        {
            TicketNumber = ticketNumber;
            Type = type;
            MyShowing = myShowing;
        }
    }
}
