using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordicBio.api.Domain
{
    public class FoodOrder
    {
        public List<Soda> sodas { get; set; }
        //public List<Candy> candies { get; set; }
        public decimal TotalPrice { get; set; }
    }
}