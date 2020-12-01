namespace NordicBio.model
{
    public class SeatDTO
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public int OrderID { get; set; }

        public SeatDTO(int Row, int Number, int OrderID)
        {
            this.Row = Row;
            this.Number = Number;
            this.OrderID = OrderID;
        }
    }
}
