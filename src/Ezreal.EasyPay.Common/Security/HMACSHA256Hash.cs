using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.Common.Security
{
    public class HMACSHA256Hash
    {
        public static string HashString(string data, string key, string encoding = "UTF-8")
        {
            using (var hmacSha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hash = hmacSha256.ComputeHash(Encoding.GetEncoding(encoding).GetBytes(data));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        public static byte[] HashBuffer(byte[] data, byte[] key)
        {
            using (var hmacSha256 = new HMACSHA256(key))
            {
                return hmacSha256.ComputeHash(data);
            }
        }
    }
}
