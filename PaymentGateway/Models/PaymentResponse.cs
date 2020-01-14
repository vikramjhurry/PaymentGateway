using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    public class PaymentResponse
    {
        public string Identifier { get; set; }
        public string Status { get; set; }
    }
}
