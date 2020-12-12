using System;

namespace NordicBio.model
{
    public class SeatDTO
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public int ShowingID { get; set; }
        public int OrderID { get; set; }
        public string State { get; set; }
        public string ReserveTime { get; set; }
        public string UUID { get; set; }

        public SeatDTO()
        {

        }

        public SeatDTO(int Row, int Number, int OrderID)
        {
            this.Row = Row;
            this.Number = Number;
            this.OrderID = OrderID;
        }
    }
}
