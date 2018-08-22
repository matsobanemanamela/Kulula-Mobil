using System;
using System.Collections.Generic;
using System.Text;

namespace Kulula.com.Models
{
    class FlightBooking
    {
        public int FlightID { get; set; }
        public int CustomerID { get; set; }
        public int AirportID { get; set; }
        public int ExtraID { get; set; }
        public string SeatNumber { get; set; }
        public string ReturningDate { get; set; }
        public int NumberOfTravellers { get; set; }
        public double TotalFare { get; set; }
    }
}
