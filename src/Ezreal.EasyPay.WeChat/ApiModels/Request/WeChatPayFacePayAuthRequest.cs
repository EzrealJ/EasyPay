using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Ezreal.EasyPay.Abstractions.ApiModels;

namespace Ezreal.EasyPay.WeChat.ApiModels.Request
{
    /// <summary>
    /// 微信支付获取人脸调用凭证请求模型
    /// </summary>
    [XmlRoot("xml")]
    public class WeChatPayFacePayAuthRequest : WeChatPayServiceProviderCompatibleRequest, ISupportCompleted
    {
        /// <summary>
        /// 门店编号
        /// </summary>
        [XmlElement("store_id")]
        public string StoreId { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        [XmlElement("store_name")]
        public string StoreName { get; set; }
        /// <summary>
        /// 终端编号
        /// </summary>
        [XmlElement("device_id")]
        public string DeviceId { get; set; }
        /// <summary>
        /// 附加字段
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }
        /// <summary>
        /// 初始化数据。由微信人脸SDK的接口返回
        /// </summary>
        [XmlElement("rawdata")]
        public string RawData { get; set; }
        /// <summary>
        /// 当前时间
        /// <para>
        ///10位unix时间戳,默认实现为DateTime.Now.ToUniversalTime().Ticks / 10000000 - 62135596800
        /// </para>
        /// </summary>
        [XmlElement("now")]
        public long Now { get; set; } = DateTime.Now.ToUniversalTime().Ticks / 10000000 - 62135596800;
        /// <summary>
        /// 版本号 固定为1
        /// </summary>
        [XmlElement("version")]
        public string Version { get; set; } = "1";
    }
}
