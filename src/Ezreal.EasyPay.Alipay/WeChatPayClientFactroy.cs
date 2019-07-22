using Ezreal.EasyPay.WeChat.Api;
using Ezreal.EasyPay.WeChat.ApiContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace Ezreal.EasyPay.WeChat
{
    public class WeChatPayClientFactroy
    {
        
#if NETSTANDARD2_0
        /// <summary>
        /// 为指定商户配置
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="handlerFactory"></param>
        /// <returns></returns>
        public static HttpApiFactory<IWeChatPayContract> Configure(string merchantId, Func<HttpClientHandler> handlerFactory = null) =>
            HttpApi.Register<IWeChatPayContract>($"{merchantId}_{nameof(IWeChatPayContract)}").ConfigureHttpMessageHandler(() =>
            {

                HttpClientHandler handler = handlerFactory?.Invoke() ?? new HttpClientHandler();
                X509Certificate x509 = WeChatPayCredentials.GetCertificate(merchantId);
                if (x509 != null)
                {
                    handler.ClientCertificates.Add(x509);
                }

                return handler;
            });
#endif

#if NET45
        /// <summary>
        /// 为指定商户配置
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="handlerFactory"></param>
        /// <returns></returns>
        public static HttpApiFactory<IWeChatPayContract> Configure(string merchantId, Func<WebRequestHandler> handlerFactory = null) =>
            HttpApi.Register<IWeChatPayContract>($"{merchantId}_{nameof(IWeChatPayContract)}").ConfigureHttpMessageHandler(() =>
            {

                WebRequestHandler handler = handlerFactory?.Invoke() ?? new WebRequestHandler();
                X509Certificate x509 = WeChatPayCredentials.GetCertificate(merchantId);
                if (x509 != null)
                {
                    handler.ClientCertificates.Add(x509);

                }
                return handler;
            });
#endif
        /// <summary>
        /// 检查商户是否已经配置过
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public static bool CheckConfigure(string merchantId) => HttpApi.Resolve<IWeChatPayContract>($"{merchantId}_{nameof(IWeChatPayContract)}") != null;
        /// <summary>
        /// 创建<see cref="WeChatPayClient"/>实例
        /// </summary>
        /// <returns></returns>
        public static WeChatPayClient CreateWeChatPayClient() => new WeChatPayClient();


    }
}
