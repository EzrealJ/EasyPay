﻿using System.Xml.Serialization;

namespace Ezreal.EasyPay.WeChat.Domain
{
    public class CouponInfo
    {
        /// <summary>
        /// 代金券类型
        /// </summary>
        [XmlElement("coupon_type")]
        public string CouponType { get; set; }

        /// <summary>
        /// 代金券ID
        /// </summary>
        [XmlElement("coupon_id")]
        public string CouponId { get; set; }

        /// <summary>
        /// 代金券金额
        /// </summary>
        [XmlElement("coupon_fee")]
        public int CouponFee { get; set; }
    }
}
