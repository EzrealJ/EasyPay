using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.WeChat.ApiContract;
using Microsoft.Extensions.DependencyInjection;
using WebApiClient.Extensions.DependencyInjection;
using Ezreal.EasyPay.Abstractions.Extensions;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;

namespace Ezreal.EasyPay.WeChat.Extension
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddEasyPayWeChat(
            this IServiceCollection services,
            Func<IServiceProvider, X509Certificate> certificateFactory,
            Func<IServiceProvider, HttpClientHandler> handlerFactory = null)
        {
            services.AddHttpApi<IWeChatPayAuthContract>().ConfigureCertificate(certificateFactory,handlerFactory);
            services.AddHttpApi<IWeChatPayContract>().ConfigureCertificate(certificateFactory, handlerFactory);
            return services;
        }
        public static IServiceCollection AddEasyPayWeChat(this IServiceCollection services)
        {
            services.AddHttpApi<IWeChatPayAuthContract>().ConfigureCertificate(sp=>GetCertificate(sp));
            services.AddHttpApi<IWeChatPayContract>().ConfigureCertificate(sp => GetCertificate(sp));
            return services;
        }

        private static X509Certificate GetCertificate(IServiceProvider sp)
        {
            WeChatPayOptions weChatPayOptions = sp.GetRequiredService<WeChatPayOptions>();
            return weChatPayOptions.Certificate;
        }
    }
}
