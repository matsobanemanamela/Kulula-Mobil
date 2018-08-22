using System;
using System.Collections.Generic;
using System.Text;

namespace Kulula.com.Models
{
    class SeatSelectionModel
    {
        public string SeatType { get; set; }
        public string SeatNumber { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double Total { get; set; }
        public int AirportID { get; set; }
    }
}
