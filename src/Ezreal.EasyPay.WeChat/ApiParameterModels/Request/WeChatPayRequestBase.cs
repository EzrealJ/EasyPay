using Ezreal.EasyPay.Abstractions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Request
{
    public class WeChatPayRequestBase
    {
        /// <summary>
        /// 公众账号ID
        /// <para>
        /// appid 是商户在微信申请公众号成功后分配的帐号 ID，登录平台为mp.weixin.qq.com
        /// </para>
        /// </summary>
        [AliasAs("appid"), MustProvide]
        public string AppId { get; set; }
        /// <summary>
        /// 特约商户公众账号ID
        /// <para>
        /// 服务商模式专有参数，微信分配的特约商户公众账号ID
        /// </para>
        /// </summary>
        [AliasAs("sub_appid")]
        public string SubAppId { get; set; }
        /// <summary>
        /// 商户号
        /// <para>
        /// 微信支付分配的商户号
        /// </para>
        /// </summary>
        [AliasAs("mch_id"), MustProvide]
        public string MchId { get; set; }
        /// <summary>
        /// 特约商户号
        /// <para>
        /// 服务商模式下必填,微信支付分配的特约商户号
        /// </para>
        /// </summary>
        [AliasAs("sub_mch_id"), MustProvide]
        public string SubMchId { get; set; }
        /// <summary>
        /// 随机字符串
        /// <para>
        /// 随机字符串，不长于 32 位。推荐随机数生成算法
        /// </para>
        /// <para>默认使用Guid.NewGuid().ToString("n")实现</para>
        /// </summary>
        [AliasAs("nonce_str"), MustProvide]
        public string NonceStr { get; set; } = Guid.NewGuid().ToString("N");
    }
}
