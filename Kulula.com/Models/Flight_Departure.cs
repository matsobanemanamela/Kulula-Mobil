using System;
using System.Collections.Generic;
using System.Text;

namespace Kulula.com.Models
{
    class Flight_Departure
    {
        public int AirportID { get; set; }
        public int AircraftID { get; set; }
        public int ArrivalID { get; set; }
        public string AirportName { get; set; }
        public string DepartingTime { get; set; }
        public string DepartingDate { get; set; }
    }
}
