using System.Xml.Serialization;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Response
{
    /// <summary>
    /// 微信支付响应模型
    /// </summary>

    public abstract class WeChatPayResponse : Abstractions.ApiParameterModels.Response.IResponseModel
    {
        /// <summary>
        /// 原始内容
        /// </summary>
        [XmlIgnore]
        public string OriginalContent { get; set; }
        /// <summary>
        /// 返回状态码
        /// 此字段是通信标识，非交易标识，
        /// 交易是否成功需要查看result_code来判断
        /// </summary>
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息，如非空，为错误原因
        /// 签名失败
        /// 参数格式校验错误
        /// </summary>
        [XmlElement("return_msg")]
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 存在有效的业务响应
        /// </summary>
        [XmlIgnore]
        public bool ExistsBusinessResponseContent { get => (!string.IsNullOrWhiteSpace(this.ReturnCode)) && (this.ReturnCode.ToUpper().Equals("SUCCESS")); }




    }
}