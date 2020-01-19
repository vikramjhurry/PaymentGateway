using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Interfaces;
using PaymentGateway.Models;
using PaymentGateway.Repository;
using PaymentGateway.Services;
using Newtonsoft.Json;

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IBankService _bankService;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public PaymentController(IBankService bankService)
        {
            _bankService = bankService;
        }

        // GET: api/Payment
        [HttpGet]
        public IEnumerable<PaymentRecord> Get()
        {
            var context = new PaymentsStorageContext();
            var payments = context.PaymentRecords.AsEnumerable();

            return payments;
        }

        // GET: api/Payment/5
        [HttpGet("{id}", Name = "Get")]
        public PaymentRecord Get(string id)
        {
            Guid paymentIdentifier = new Guid(id);

            var context = new PaymentsStorageContext();
            PaymentRecord payment = context.PaymentRecords
                .Where(s => s.Identifier == id).FirstOrDefault();

            payment.CardNo = payment.CardNo.Replace(payment.CardNo.Substring(0, 14), "*************");
            return payment;
        }

        // POST: api/Payment
        [HttpPost]
        public PaymentResponse Post([FromBody] PaymentInformation paymentInformation)
        {
            log.Info("POST-REQUEST:" + JsonConvert.SerializeObject( paymentInformation));
            try
            {
                EncryptedPaymentInformation encryptedPaymentInformation = new EncryptedPaymentInformation();
                //Encrypt data before sending to bank
                encryptedPaymentInformation = EncryptData(paymentInformation);

                PaymentResponse response = _bankService.PaymentRequest(encryptedPaymentInformation);
                using (var context = new PaymentsStorageContext())
                {
                    var paymentRecord = new PaymentRecord()
                    {
                        CardNo = paymentInformation.CardNo,
                        Expiry = paymentInformation.Expiry,
                        Status = response.Status,
                        Identifier = response.Identifier

                    };
                    context.PaymentRecords.Add(paymentRecord);
                    context.SaveChanges();
                }
                log.Info("POST-RESPONSE:" + JsonConvert.SerializeObject(response));
                return response;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

                return null;
            }
           
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
