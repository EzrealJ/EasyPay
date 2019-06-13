using Ezreal.EasyPay.WeChat.Api;
using Ezreal.EasyPay.WeChat.ApiContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace Ezreal.EasyPay.WeChat
{
    public class WeChatClientFactroy
    {
        /// <summary>
        /// 配置
        /// </summary>
        /// <returns></returns>
        public static HttpApiFactory<IWeChatPayContract> Configure() => HttpApi.Register<IWeChatPayContract>();
        /// <summary>
        /// 在多商户模式下为指定商户配置
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public static HttpApiFactory<IWeChatPayContract> ConfigureAsMultiMerchant(string merchantId) => HttpApi.Register<IWeChatPayContract>($"{merchantId}_{nameof(IWeChatPayContract)}");

        /// <summary>
        /// 创建<see cref="WeChatPayClient"/>实例
        /// </summary>
        /// <returns></returns>
        public static WeChatPayClient CreateWeChatPayClient() => new WeChatPayClient();


    }
}
