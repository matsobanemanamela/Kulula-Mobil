using System;
using System.Collections.Generic;
using System.Text;

namespace Kulula.com.Models
{
    class InternetPaymentSID
    {
        public int InternetPaymentID { get; set; }
        public int PaymentID { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string CardNumber { get; set; }
    }
}
