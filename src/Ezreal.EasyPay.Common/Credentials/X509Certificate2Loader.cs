using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.Common.Credentials
{
    public class X509Certificate2Loader
    {
        public static X509Certificate2 FromPemString(string pem, string password = null)
        {
            byte[] data = GetBytesFromPemString(pem, "CERTIFICATE");
            if (string.IsNullOrWhiteSpace(password))
            {
                return new X509Certificate2(data);
            }
            return new X509Certificate2(data, password,X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
        }
        public static X509Certificate2 FromFile(string path, string password = null)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return new X509Certificate2(path);
            }
            return new X509Certificate2(path, password);
        }
        private static byte[] GetBytesFromPemString(string pem, string type)
        {
            string header = string.Format("-----BEGIN {0}-----\r\n", type);
            string footer = string.Format("-----END {0}-----", type);
            int start = pem.IndexOf(header) + header.Length;
            int end = pem.IndexOf(footer, start);
            string base64 = pem.Substring(start, (end - start));

            return Convert.FromBase64String(base64);
        }
    }
}
