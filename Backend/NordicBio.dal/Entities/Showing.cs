using System;

namespace NordicBio.dal.Entities
{
    public class Showing
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime ShowingTime { get; set; }
        public int HallNumber { get; set; }
        public int MovieID { get; set; }

        public Showing()
        {

        }
        public Showing(double price, DateTime showingTime, int hallNumber, int movieID)
        {
            Price = price;
            ShowingTime = showingTime;
            HallNumber = hallNumber;
            MovieID = movieID;
        }


    }
}
