using System;
using System.Collections.Generic;
using System.Text;

namespace Kulula.com.Models
{
    class PreferredClass
    {
        public int PreferredClassID { get; set; }
        public int AirportID { get; set; }
        public string PreferredClassType { get; set; }
        public string FlightType { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double Total { get; set; }
    }
}
