using System;
using System.Collections;

namespace NordicBio.model
{
    public class OrderDTO
    {
        public int OrderNumber { get; set; }
        public double TotalPrice { get; set; }

        public OrderDTO(int orderNumber)
        {
            OrderNumber = orderNumber;
        }

    }
}
