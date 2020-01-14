using PaymentGateway.Interfaces;
using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services
{
    public class MockBankProcessing : IBankService
    {
        public string PaymentRequest(EncryptedPaymentInformation encryptedPaymentInformation)
        {
            string response;
            Guid transactionIdentifier = Guid.NewGuid();
            string personName = "Mr David Peterson";
            response = transactionIdentifier.ToString() + " - Payment transaction successful from " + personName;
            return response;
        }
    }
}
