using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using WebApiClient;

namespace Ezreal.EasyPay.Abstractions.Extensions
{
    public static class HttpApiFactoryExtensions
    {
        /// <summary>
        /// 为微信支付的Api契约配置商户证书
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <param name="httpApiFactory"></param>
        /// <param name="certificateFactory"></param>
        /// <param name="handlerFactory"></param>
        /// <returns></returns>
        public static HttpApiFactory<TInterface> ConfigureCertificate<TInterface>(
            this HttpApiFactory<TInterface> httpApiFactory,
            Func<X509Certificate> certificateFactory,
            Func<HttpClientHandler> handlerFactory = null)
      where TInterface : class, IHttpApi
        {
            if (httpApiFactory == null)
            {
                throw new ArgumentNullException(nameof(httpApiFactory));
            }

            if (certificateFactory is null)
            {
                throw new ArgumentNullException(nameof(certificateFactory));
            }

            if (handlerFactory != null)
            {
                httpApiFactory = httpApiFactory.ConfigureHttpMessageHandler(() =>
                {

                    HttpClientHandler handler = handlerFactory?.Invoke() ?? new HttpClientHandler();
                    X509Certificate x509 = certificateFactory();
                    if (x509 != null)
                    {
                        handler.ClientCertificates.Add(x509);
                    }
                    return handler;
                });
            }
            return httpApiFactory;
        }
    }
}
