using Ezreal.EasyPay.Abstractions.ApiParameterModels.Request;
using Ezreal.EasyPay.Abstractions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Request
{
    /// <summary>
    /// 微信支付请求模型
    /// </summary>
    [XmlRoot("xml")]
    public abstract class WeChatPayRequest: IRequestModel
    {
        /// <summary>
        /// 公众账号ID
        /// <para>
        /// appid 是商户在微信申请公众号成功后分配的帐号 ID，登录平台为mp.weixin.qq.com
        /// </para>
        /// </summary>
        [XmlElement("appid"), MustProvide]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// <para>
        /// 微信支付分配的商户号
        /// </para>
        /// </summary>
        [XmlElement("mch_id"), MustProvide]
        public string MchId { get; set; }


        /// <summary>
        /// 随机字符串
        /// <para>
        /// 随机字符串，不长于 32 位。推荐随机数生成算法
        /// </para>
        /// <para>默认使用Guid.NewGuid().ToString("n")实现</para>
        /// </summary>
        [XmlElement("nonce_str"), MustProvide]
        public virtual string NonceStr { get; set; } = Guid.NewGuid().ToString("N");
    }
}
