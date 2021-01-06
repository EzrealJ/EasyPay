using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using WebApiClient;
using WebApiClient.Extensions.DependencyInjection;

namespace Ezreal.EasyPay.Abstractions.Extensions
{
    public static class HttpApiFactoryBuilderExtensions
    {
        /// <summary>
        /// 接口配置证书
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <param name="httpApiFactoryBuilder"></param>
        /// <param name="certificateFactory"></param>
        /// <param name="handlerFactory"></param>
        /// <returns></returns>
        public static HttpApiFactoryBuilder<TInterface> ConfigureCertificate<TInterface>(
            this HttpApiFactoryBuilder<TInterface> httpApiFactoryBuilder,
            Func<IServiceProvider, X509Certificate> certificateFactory,
            Func<IServiceProvider, HttpClientHandler> handlerFactory = null)
      where TInterface : class, IHttpApi
        {
            if (httpApiFactoryBuilder == null)
            {
                throw new ArgumentNullException(nameof(httpApiFactoryBuilder));
            }

            if (certificateFactory is null)
            {
                throw new ArgumentNullException(nameof(certificateFactory));
            }

            if (handlerFactory != null)
            {
                httpApiFactoryBuilder = httpApiFactoryBuilder.ConfigureHttpMessageHandler((IServiceProvider sp) =>
                {

                    HttpClientHandler handler = handlerFactory?.Invoke(sp) ?? new HttpClientHandler();
                    X509Certificate x509 = certificateFactory(sp);
                    if (x509 != null)
                    {
                        handler.ClientCertificates.Add(x509);
                    }
                    return handler;
                });
            }
            return httpApiFactoryBuilder;
        }
    }
}
