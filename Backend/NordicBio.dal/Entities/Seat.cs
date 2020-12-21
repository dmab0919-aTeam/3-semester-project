namespace NordicBio.dal.Entities
{
    public class Seat
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public int ShowingID { get; set; }
        public int OrderID { get; set; }
        public string State { get; set; }
        public string ReserveTime { get; set; }
        public string UUID { get; set; }

    }
}
