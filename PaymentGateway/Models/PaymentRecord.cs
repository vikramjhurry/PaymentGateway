using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    public class PaymentRecord
    {
        [Key]
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string CardNo { get; set; }
        public string Expiry { get; set; }
        public string Status { get; set; }
    }
}
