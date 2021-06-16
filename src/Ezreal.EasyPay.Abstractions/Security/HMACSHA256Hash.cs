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
        public static string HashToHex(string value, string key, string encoding = "UTF-8")
        {
            using (HMACSHA256 hmacSha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hash = hmacSha256.ComputeHash(Encoding.GetEncoding(encoding).GetBytes(value));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }


        /// <summary>
        /// HMACSHA256哈希加密为Base64字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HashToBase64(string value, string key, string encoding = "UTF-8")
        {
            if (string.IsNullOrWhiteSpace(encoding))
            {
                throw new ArgumentException("message", nameof(encoding));
            }
            Encoding en = Encoding.GetEncoding(encoding);
            using (HMACSHA256 hmacSha256 = new HMACSHA256(en.GetBytes(key)))
            {
                byte[] hash = hmacSha256.ComputeHash(en.GetBytes(value));
                return Convert.ToBase64String(hash);
            }
        }

        public static byte[] HashBuffer(byte[] data, byte[] key)
        {
            using (HMACSHA256 hmacSha256 = new HMACSHA256(key))
            {
                return hmacSha256.ComputeHash(data);
            }
        }
    }
}
