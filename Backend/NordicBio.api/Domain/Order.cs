using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordicBio.api.Domain
{
    public class Order
    {
        public Customer customer { get; set; }
        public FoodOrder foodOrder { get; set; }
        //public List<Ticket> tickets { get; set; }
    }
}