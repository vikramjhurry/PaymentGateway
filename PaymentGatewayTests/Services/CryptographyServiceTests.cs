using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentGateway.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Services.Tests
{
    [TestClass()]
    public class CryptographyServiceTests
    {
        [TestMethod()]
        public void EncryptTextTest()
        {
            string f = "COMMON";
            CryptographyService cryptographyService = new CryptographyService();
            string result=cryptographyService.EncryptText(f);

            Assert.IsNotNull(result);
        }
    }
}