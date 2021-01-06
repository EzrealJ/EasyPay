using Ezreal.EasyPay.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.WeChat
{
    /// <summary>
    /// 将其注入到依赖注入容器,读取证书时将从容器获取它并读取其<see cref="Certificate"/>成员
    /// <para>具体生命周期自行判断；例如:仅一个商户注册为<see cref="ServiceLifetime.Singleton"/>,多租户web注册为<see cref="ServiceLifetime.Scoped"/>,后台同步任务注册为<see cref="ServiceLifetime.Transient"/></para>
    /// </summary>
    public class WeChatPayOptions : IOptions
    {

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
        /// <summary>
        /// 证书信息
        /// <para>证书最终都转换成这个类型，具体方法百度</para>
        /// </summary>
        public X509Certificate Certificate { get; set; }
    }
}
