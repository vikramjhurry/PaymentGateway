﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    public class PaymentResponse
    {
        [Key]
        public int id { get; set; }
        public string Identifier { get; set; }
        public string Status { get; set; }
    }
}
