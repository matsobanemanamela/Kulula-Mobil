using System;
using System.Collections.Generic;
using System.Text;

namespace Kulula.com.Models
{
    class CreditCard
    {
        public int CreditID { get; set; }
        public Nullable<int> PaymentID { get; set; }
        public string CardNumber { get; set; }
        public string Cardname { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
