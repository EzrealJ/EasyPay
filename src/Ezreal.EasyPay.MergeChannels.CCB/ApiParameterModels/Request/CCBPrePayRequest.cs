using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Ezreal.EasyPay.Abstractions.Attributes;
using Ezreal.EasyPay.MergeChannels.CCB.Enums;
using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Request
{
    public class CCBPrePayRequest : CCBPayRequest
    {


        [SignOrder(6)]
        public override string TXCODE { get; } = "530550";
        /// <summary>
        /// 订单Id
        /// <para>
        /// 由商户提供，最长30位。需按以下规则生成订单号：商户代码(15位)+自定义字符串(不超过15位)。字符串可包含数字、字母、下划线。商户需保证订单号唯一。
        /// </para>
        /// </summary>
        [AliasAs("ORDERID")]
        [SignOrder(3)]
        public string OrderId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(MerchantId))
                {
                    throw new MemberAccessException($"{nameof(MerchantId)} not be null");
                }
                if (string.IsNullOrWhiteSpace(OrderIdSuffix))
                {
                    throw new MemberAccessException($"{nameof(OrderIdSuffix)} not be null");
                }
                if (MerchantId.Length != 15)
                {
                    throw new IndexOutOfRangeException($"length of {nameof(MerchantId)} must be 15");
                }
                return MerchantId + OrderIdSuffix;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new MemberAccessException($"{nameof(value)} not be null");
                }
                string orderIdPrefix = value.Substring(0, 15);
                if(orderIdPrefix!=MerchantId)
                {
                    throw new MemberAccessException($"{ nameof(value) } prefix must be MerchantId");
                }
                OrderIdSuffix = value.Substring(15, value.Length - 15);
            }
        }

        [IgnoreSerialized]
        public string OrderIdSuffix { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [AliasAs("PAYMENT")]
        [SignOrder(4)]
        public decimal Amount { get; set; }
        /// <summary>
        /// 货币代码
        /// </summary>
        [AliasAs("CURCODE")]
        [SignOrder(5)]
        public string CurrencyCode { get; set; } = "01";
        /// <summary>
        /// 备注1
        /// </summary>
        [AliasAs("REMARK1")]
        [SignOrder(7)]
        public string Remark1 { get; set; }
        /// <summary>
        /// 备注1
        /// </summary>
        [AliasAs("REMARK2")]
        [SignOrder(8)]
        public string Remark2 { get; set; }
        /// <summary>
        /// 0或空：返回页面二维码
        /// 1：返回JSON格式【二维码信息串】
        /// 2：返回聚合扫码页面二维码
        /// 3：返回聚合扫码JSON格式【二维码信息串】
        /// 聚合扫码只能上送2或3
        /// </summary>
        [AliasAs("RETURNTYPE")]
        [SignOrder(9)]
        public EnumReturnType ReturnType { get; set; }
        /// <summary>
        /// 格式：YYYYMMDDHHMMSS如：20120214143005 银行系统时间> TIMEOUT时拒绝交易，若送空值则不判断超时。
        /// </summary>
        [AliasAs("TIMEOUT")]
        [SignOrder(10)]
        public DateTime? Timeout { get; set; }
        /// <summary>
        /// 对应柜台的公钥后30位
        /// </summary>
        [AliasAs("PUB")]
        [IgnoreSerialized]
        [SignOrder(11)]
        public string Pub { get; set; }
        /// <summary>
        /// 采用标准MD5算法，由商户实现
        /// </summary>
        [AliasAs("MAC")]
        public string Mac => CalculateMac();

        protected static PropertyInfo[] PropertyInfos = typeof(CCBPrePayRequest).GetProperties();
        protected virtual string CalculateMac()
        {
            SortedDictionary<int, PropertyInfo> signPropertyInfosSort = new SortedDictionary<int, PropertyInfo>();
            foreach (PropertyInfo propertyInfo in PropertyInfos)
            {
                SignOrderAttribute signOrderAttribute = propertyInfo.GetCustomAttribute<SignOrderAttribute>();
                if (signOrderAttribute == null || signOrderAttribute.Order < 0)
                {
                    continue;
                }
                signPropertyInfosSort.Add(signOrderAttribute.Order, propertyInfo);
            }
            StringBuilder stringBuilder = null;
            foreach (KeyValuePair<int, PropertyInfo> item in signPropertyInfosSort)
            {
                if (stringBuilder == null)
                {
                    stringBuilder = new StringBuilder();
                }
                else
                {
                    stringBuilder.Append("&");
                }
                string parameterName = item.Value.GetCustomAttribute<AliasAsAttribute>()?.Name;
                stringBuilder.Append(parameterName + "=" + item.Value.GetValue(this)?.ToString());
            }
            return Common.Security.MD5Hash.HashToHex(stringBuilder.ToString());

        }
    }
}
