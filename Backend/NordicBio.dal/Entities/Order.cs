using System.Collections;

namespace NordicBio.dal.Entities
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public double TotalPrice { get; set; }
        ArrayList tickets;

        public Order(int orderNumber)
        {
            OrderNumber = orderNumber;
            TotalPrice = CalculateTotalPrice();
            tickets = new ArrayList();
        }

        public void AddTicket(Ticket newTicket)
        {
            tickets.Add(newTicket);
        }

        public double CalculateTotalPrice()
        {
            double res = 0;
            foreach (Ticket t in tickets)
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
