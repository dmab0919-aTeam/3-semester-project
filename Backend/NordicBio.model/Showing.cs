using System;
using System.Collections;

namespace NordicBio.model
{
    public class Showing
    {
        public double Price { get; set; }
        public DateTime Time { get; set; }
        public int HallNumber { get; set; }
        public Movie MyMovie { get; set; }
        ArrayList seats;

        public Showing(double price, DateTime time, int hallNumber, Movie myMovie)
        {
            Price = price;
            Time = time;
            HallNumber = hallNumber;
            MyMovie = myMovie;
            seats = new ArrayList();
        }

        public void AddSeat(Seat newSeat) 
        {
            seats.Add(newSeat);
        }
    }
}
