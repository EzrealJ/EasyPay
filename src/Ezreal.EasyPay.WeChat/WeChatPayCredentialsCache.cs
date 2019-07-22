using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Ezreal.EasyPay.WeChat
{
    /// <summary>
    /// 微信支付证书缓存
    /// </summary>
    public class WeChatPayCredentialsCache
    {
        /// <summary>
        /// 默认提供的实例,使用于没有DI的环境
        /// </summary>
        public static WeChatPayCredentialsCache DefaultInstance { get; set; } = new WeChatPayCredentialsCache();
        /// <summary>
        /// 线程安全的证书字典
        /// </summary>
        private readonly ConcurrentDictionary<string, X509Certificate> _x509CertificateConcurrentDictionary = new ConcurrentDictionary<string, X509Certificate>();
        public void AddOrUpdateCredentials(string merchantId, X509Certificate certificate) => _x509CertificateConcurrentDictionary.AddOrUpdate(merchantId, certificate, (m, c) => certificate);
        /// <summary>
        /// 从文件为商户配置证书
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="certificateFilePath"></param>
        /// <exception cref="FileNotFoundException">指定的证书文件未找到</exception>
        public void AddOrUpdateCredentials(string merchantId, string certificateFilePath)
        {
            if(!File.Exists(certificateFilePath))
            {
                throw new FileNotFoundException("证书文件未找到", certificateFilePath);
            }
            X509Certificate2 x509 = new X509Certificate2(certificateFilePath, merchantId, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            AddOrUpdateCredentials(merchantId, x509);
        }
        /// <summary>
        /// 从字节数组为商户配置证书
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="certificateData"></param>
        public void AddOrUpdateCredentials(string merchantId, byte[] certificateData)
        {
            X509Certificate2 x509 = new X509Certificate2(certificateData, merchantId, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            AddOrUpdateCredentials(merchantId, x509);
        }
        /// <summary>
        /// 获取指定商户的证书
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public X509Certificate GetCertificate(string merchantId) => _x509CertificateConcurrentDictionary.ContainsKey(merchantId) ? _x509CertificateConcurrentDictionary[merchantId] : null;



    }
}
