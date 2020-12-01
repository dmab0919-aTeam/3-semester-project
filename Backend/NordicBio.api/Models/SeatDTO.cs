namespace NordicBio.model
{
    public class SeatDTO
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public int ShowingID { get; set; }

        public SeatDTO(int Row, int Number, int ShowingID)
        {
            this.Row = Row;
            this.Number = Number;
            this.ShowingID = ShowingID;
        }
    }
}
