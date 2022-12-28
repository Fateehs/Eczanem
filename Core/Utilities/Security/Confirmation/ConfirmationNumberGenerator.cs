using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Confirmation
{
    public class ConfirmationNumberGenerator
    {
        public static void Generate()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            byte[] randomNumber = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomNumber);

            string confirmationNumber = timestamp + BitConverter.ToUInt32(randomNumber, 0).ToString();
        }
    }
}
