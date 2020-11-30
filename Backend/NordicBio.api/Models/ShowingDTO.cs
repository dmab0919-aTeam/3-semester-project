using System;

namespace NordicBio.model
{
    public class ShowingDTO
    {
        public double Price { get; set; }
        public DateTime ShowingTime { get; set; }
        public int HallNumber { get; set; }
        public int MovieID { get; set; }

        public ShowingDTO()
        {

        }
        public ShowingDTO(double price, DateTime showingTime, int hallNumber, int movieID)
        {
            Price = price;
            ShowingTime = showingTime;
            HallNumber = hallNumber;
            MovieID = movieID;
        }


    }
}
