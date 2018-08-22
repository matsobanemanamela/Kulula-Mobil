using System;
using System.Collections.Generic;
using System.Text;

namespace Kulula.com.Models
{
    class Payments
    {
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public string PaymentType { get; set; }
        public double TotalAmount { get; set; }
    }
}
