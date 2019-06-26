using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;

namespace Ezreal.EasyPay.WeChat
{
    public class WeChatPayCredentials
    {
        private static readonly ConcurrentDictionary<string, X509Certificate> _x509Certificate = new ConcurrentDictionary<string, X509Certificate>();
        public static void AddOrUpdateCredentials(string merchantId, X509Certificate certificate) => _x509Certificate.AddOrUpdate(merchantId, certificate, (m, c) => certificate);
        public static void AddOrUpdateCredentials(string merchantId, byte[] certificateData)
        {
            X509Certificate2 x509 = new X509Certificate2(certificateData, merchantId, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            AddOrUpdateCredentials(merchantId, x509);
        }
        public static X509Certificate GetCertificate(string merchantId) => _x509Certificate.ContainsKey(merchantId) ? _x509Certificate[merchantId] : null;



    }
}
