using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    public class PaymentInformation
    {
        public string CardNo { get; set; }
        public string Expiry { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string CVV { get; set; }
       
    }
}
