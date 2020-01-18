using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentGateway.Controllers;
using PaymentGateway.Models;
using PaymentGateway.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Controllers.Tests
{
    [TestClass()]
    public class PaymentControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
            PaymentInformation paymentInformation = new PaymentInformation() { CardNo = "3456-3457-1234-3457", Amount = 450.34,Currency="USD", Expiry = "12/2025", CVV = "354" };
            MockBankProcessing mockBankProcessing = new MockBankProcessing();
            PaymentController paymentController = new PaymentController(mockBankProcessing);
            var response = paymentController.Post(paymentInformation);
            Assert.IsNotNull(response);
        }
    }
}