using System;
using System.Collections;

namespace NordicBio.model
{
    public class OrderModel
    {
        public int OrderNumber { get; set; }
        public double TotalPrice { get; set; }
        ArrayList tickets;

        public OrderModel(int orderNumber)
        {
            OrderNumber = orderNumber;
            TotalPrice = CalculateTotalPrice();
            tickets = new ArrayList();
        }

        public void AddTicket(TicketModel newTicket) 
        {
            tickets.Add(newTicket);
        }

        public double CalculateTotalPrice() 
        {
            double res = 0;
            foreach (TicketModel t in tickets) 
            {
                if (t.Type == "Child")
                {
                    res += t.MyShowing.Price * 0.8;
                }
                else
                {
                    res += t.MyShowing.Price;
                }
            }
            return res;
        }
    }
}
