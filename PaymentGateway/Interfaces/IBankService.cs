using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Interfaces
{
    public interface IBankService
    {
        public string PaymentRequest(EncryptedPaymentInformation encryptedPaymentInformation);
    }
}
