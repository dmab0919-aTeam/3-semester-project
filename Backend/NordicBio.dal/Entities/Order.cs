using System.Collections;

namespace NordicBio.dal.Entities
{
    public class Order
    { 
        public double TotalPrice { get; set; }
        public int UserID { get; set; }
        public int ShowingID { get; set; }

        public Order()
        {
            
        }
    }
}
