using System;
using System.Collections.Generic;
using System.Text;

namespace Kulula.com.Models
{
    class Cart
    {
        public int CartID { get; set; }
        public int PreferredClassID { get; set; }
        public string SeatNumber { get; set; }
        public Nullable<int> ExtraID { get; set; }
        public double Totalprice { get; set; }
        public double Quantity { get; set; }
    }
}
