using System.Security.Cryptography;
using System.Text;

namespace rock_paper_scissors_game.Services.Security
{
    internal class SecurityService
    {

        public string GenerateCryptographicallyKey()
        {
            string secureRandomString = "";
            var cryptoProvider = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[32];
            cryptoProvider.GetBytes(bytes);

            secureRandomString = Convert.ToBase64String(bytes);

            return secureRandomString;
        }

        public string GenerateHmacValue(string key, string message)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes(key);
            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
            return ByteToString(hashmessage);
        }

        public string ByteToString(byte[] bytes)
        {
            var value = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                value.Append(bytes[i].ToString("x2"));
            }

            return value.ToString();
        }
    }
}
