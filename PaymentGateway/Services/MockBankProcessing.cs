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
        public PaymentResponse PaymentRequest(EncryptedPaymentInformation encryptedPaymentInformation)
        {
            PaymentResponse response=new PaymentResponse();
            Guid transactionIdentifier = Guid.NewGuid();
            string personName = "Mr David Peterson";

            response.Identifier = transactionIdentifier.ToString();
            response.Status = "SUCCESS";
            return response;
        }
    }
}
