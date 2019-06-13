using Ezreal.EasyPay.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.WeChat
{
    public class WeChatOptions : IOptions
    {
        public static  WeChatOptions DefaultInstance { get; set; } = new WeChatOptions();
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

        ///// <summary>
        ///// 日志等级
        ///// </summary>
        //public LogLevel LogLevel { get; set; } = LogLevel.Information;
    }
}
