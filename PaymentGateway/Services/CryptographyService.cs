using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Services
{
    public class CryptographyService
    {
        private Aes CreateCipher()
        {
            
            Aes cipher = Aes.Create();
            cipher.Padding = PaddingMode.ISO10126;
            //cipher.Key = new byte[] {};
            return cipher;
        }

        public string EncryptText(string text)
        {
            Aes cipher = CreateCipher();

            ICryptoTransform cryptoTransform = cipher.CreateEncryptor();
            byte[] originalText = Encoding.UTF8.GetBytes(text);
            byte[] encryptedText = cryptoTransform.TransformFinalBlock(originalText, 0, originalText.Length);

            string encryptedString = Convert.ToBase64String(encryptedText);
            return encryptedString;
        }
    }
}
