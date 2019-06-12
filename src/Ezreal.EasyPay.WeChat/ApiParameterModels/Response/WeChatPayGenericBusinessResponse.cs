using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Response
{
    /// <summary>
    /// 微信支付接口的通用响应模型
    /// </summary>
    public abstract class WeChatPayGenericBusinessResponse : WeChatPayResponse
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        [XmlElement("appid")]
        public string AppId { get; set; }



        /// <summary>
        /// 商户号
        /// </summary>
        [XmlElement("mch_id")]
        public string MchId { get; set; }


        /// <summary>
        /// 随机字符串
        /// </summary>
        [XmlElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [XmlElement("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 业务结果
        /// </summary>
        [XmlElement("result_code")]
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误描述	
        /// <para>
        /// ***部分接口不会返回错误描述,但大部分接口会返回错误代码,错误描述不应成为您业务的判断依据
        /// </para>
        /// </summary>
        [XmlElement("err_code_des")]
        public string ErrCodeDes { get; set; }
        /// <summary>
        /// 结果是否有效
        /// <para>
        /// 等效于return_code=="SUCCESS"且result_code=="SUCCESS"
        /// </para>
        /// </summary>
        public bool IsEffectiveResult
        {
            get =>
            (!string.IsNullOrWhiteSpace(this.ReturnCode))
            && (!string.IsNullOrWhiteSpace(this.ResultCode))
            && this.ReturnCode.ToUpper() == "SUCCESS"
            && this.ResultCode.ToUpper() == "SUCCESS";
        }

    }
}
