using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Request
{
    public class CCBMicroPayRequest :CCBPayCommonRequestModel, ICCBPayRequest
    {
        public string TXCODE => "PAY100";
        /// <summary>
        /// 金额
        /// </summary>
        public decimal AMOUNT { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string PROINFO { get; set; }
        /// <summary>
        /// 保留字段1
        /// </summary>
        public string REMARK1 { get; set; }
        /// <summary>
        ///  保留字段2
        /// </summary>
        public string REMARK2 { get; set; }
        /// <summary>
        /// 二级商户代码
        /// </summary>
        public string SMERID { get; set; }
        /// <summary>
        /// 二级商户名称
        /// </summary>
        public string SMERNAME { get; set; }

        /// <summary>
        /// 二级商户类别代码
        /// </summary>
        public string SMERTYPEID { get; set; }
        /// <summary>
        /// 二级商户类别名称
        /// </summary>
        public string SMERTYPE { get; set; }
        /// <summary>
        /// 交易类型代码
        /// </summary>
        public string TRADECODE { get; set; }
        /// <summary>
        /// 交易类型名称
        /// </summary>
        public string TRADENAME { get; set; }
        /// <summary>
        /// 商品类别代码
        /// </summary>
        public string SMEPROTYPE { get; set; }
        /// <summary>
        /// 商品类别名称
        /// </summary>
        public string PRONAME { get; set; }

    }
}
