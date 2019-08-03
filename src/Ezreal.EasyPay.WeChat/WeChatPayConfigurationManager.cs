using Ezreal.EasyPay.WeChat.Api;
using Ezreal.EasyPay.WeChat.ApiContract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace Ezreal.EasyPay.WeChat
{
    public class WeChatPayConfigurationManager
    {
        private readonly WeChatPayCredentialsCache _weChatPayCredentialsCache;
        /// <summary>
        /// 默认提供的实例，适用于没有DI的环境或无多商户需求的场景
        /// </summary>
        public static WeChatPayConfigurationManager DefaultInstance { get; set; } = new WeChatPayConfigurationManager();

        protected virtual ConcurrentDictionary<string, object> ConfigurationConcurrentDictionary { get; set; } = new ConcurrentDictionary<string, object>();

        public WeChatPayConfigurationManager(WeChatPayCredentialsCache weChatPayCredentialsCache = null)
        {
            _weChatPayCredentialsCache = weChatPayCredentialsCache ?? WeChatPayCredentialsCache.DefaultInstance;
        }
        /// <summary>
        /// 为指定商户配置
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="options"></param>
        /// <param name="handlerFactory"></param>
        /// <param name="cleanupInterval"></param>
        /// <param name="KeepCookieContainer"></param>
        /// <param name="lifeTime"></param>
        /// <returns></returns>
        public virtual void Configure(string merchantId, Action<HttpApiConfig> options = null,
            Func<HttpClientHandler> handlerFactory = null,
           TimeSpan? cleanupInterval = null,
           bool? KeepCookieContainer = null,
           TimeSpan? lifeTime = null
           )
        {
            if (CheckConfiguration(merchantId))
            {
                throw new Exception("已为此商户配置过,无需重新进行配置,若希望更新证书,请更新证书缓存");
            }
            ConfigurationConcurrentDictionary.TryAdd(merchantId, (options, handlerFactory));
            HttpApiFactory<IWeChatPayContract> httpApiFactory = HttpApi.Register<IWeChatPayContract>($"{merchantId}_{nameof(IWeChatPayContract)}");
            if (options != null)
            {
                httpApiFactory = httpApiFactory.ConfigureHttpApiConfig(options);
            }
            if (handlerFactory != null)
            {

                httpApiFactory = httpApiFactory.ConfigureHttpMessageHandler(() =>
                 {

                     HttpClientHandler handler = handlerFactory?.Invoke() ?? new HttpClientHandler();
                     X509Certificate x509 = _weChatPayCredentialsCache.GetCertificate(merchantId);
                     if (x509 != null)
                     {
                         handler.ClientCertificates.Add(x509);
                     }

                     return handler;
                 });
            }
            if (cleanupInterval.HasValue)
            {
                httpApiFactory = httpApiFactory.SetCleanupInterval(cleanupInterval.Value);
            }
            if (KeepCookieContainer.HasValue)
            {
                httpApiFactory = httpApiFactory.SetKeepCookieContainer(KeepCookieContainer.Value);
            }
            if (lifeTime.HasValue)
            {
                httpApiFactory = httpApiFactory.SetLifetime(lifeTime.Value);
            }
        }
        /// <summary>
        /// 检查商户是否已经配置过
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public virtual bool CheckConfiguration(string merchantId) => ConfigurationConcurrentDictionary.ContainsKey(merchantId);

    }
}
