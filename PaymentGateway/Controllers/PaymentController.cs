using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Interfaces;
using PaymentGateway.Models;
using PaymentGateway.Services;

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IBankService _bankService;

        public PaymentController(IBankService bankService)
        {
            _bankService = bankService;
        }
        // GET: api/Payment
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Payment/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            Guid paymentIdentifier = new Guid(id);

            return "value";
        }

        // POST: api/Payment
        [HttpPost]
        public string Post([FromBody] PaymentInformation paymentInformation)
        {
            EncryptedPaymentInformation encryptedPaymentInformation = new EncryptedPaymentInformation();
            //Encrypt data before sending to bank
            encryptedPaymentInformation= EncryptData(paymentInformation);

            string response = _bankService.PaymentRequest(encryptedPaymentInformation);
            return response;
        }

        
        private static EncryptedPaymentInformation EncryptData(PaymentInformation paymentInformation)
        {
            EncryptedPaymentInformation encryptedPaymentInformation = new EncryptedPaymentInformation();
            CryptographyService cryptographyService = new CryptographyService();
            encryptedPaymentInformation.CardNo = cryptographyService.EncryptText(paymentInformation.CardNo);
            encryptedPaymentInformation.Expiry = cryptographyService.EncryptText(paymentInformation.Expiry);
            encryptedPaymentInformation.Amount = cryptographyService.EncryptText(paymentInformation.Amount.ToString());
            encryptedPaymentInformation.Currency = cryptographyService.EncryptText(paymentInformation.Currency);
            encryptedPaymentInformation.CVV = cryptographyService.EncryptText(paymentInformation.CVV);
            return encryptedPaymentInformation;
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
