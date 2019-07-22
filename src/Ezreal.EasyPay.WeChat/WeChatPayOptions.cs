using Ezreal.EasyPay.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.WeChat
{
    public class WeChatPayOptions : IOptions
    {
        /// <summary>
        /// 默认的微信支付配置选项,使用于简单无多商户的模式
        ///<para>
        /// 当未在请求参数中提供配置信息时,将从此实例获取配置并应用
        /// </para>
        /// </summary>
        public static  WeChatPayOptions DefaultInstance { get; set; } = new WeChatPayOptions();
        /// <summary>
        /// 应用账号(公众账号ID/小程序ID/企业号CorpId)
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 企业微信密钥(企业微信Secret，其它业务无需配置)
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// API秘钥
        /// </summary>
        public string Key { get; set; }
    }
}
