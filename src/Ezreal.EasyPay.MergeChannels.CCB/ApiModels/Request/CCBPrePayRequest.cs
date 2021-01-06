using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Ezreal.EasyPay.Abstractions.Attributes;
using Ezreal.EasyPay.MergeChannels.CCB.Enums;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Request
{
    public class CCBPrePayRequest : ICCBPayRequest,IParameterNameComparer
    {
        /// <summary>
        /// 商户代码
        /// </summary>
        [SignOrder(0)]
        public string MERCHANTID { get; set; }
        /// <summary>
        /// 柜台代码
        /// </summary>
        [SignOrder(1)]
        public string POSID { get; set; }

        /// <summary>
        /// 分行代码
        /// </summary>
        [SignOrder(2)]
        public string BRANCHID { get; set; }


        [SignOrder(6)]
        public  string TXCODE { get; } = "530550";
        /// <summary>
        /// 订单Id
        /// <para>
        /// 由商户提供，最长30位。需按以下规则生成订单号：商户代码(15位)+自定义字符串(不超过15位)。字符串可包含数字、字母、下划线。商户需保证订单号唯一。
        /// </para>
        /// </summary>

        [SignOrder(3)]
        public string ORDERID { get;set;}

        /// <summary>
        /// 金额
        /// </summary>
        [SignOrder(4)]
        public decimal PAYMENT { get; set; }
        /// <summary>
        /// 货币代码
        /// </summary>

        [SignOrder(5)]
        public string CURCODE { get; set; } = "01";
        /// <summary>
        /// 备注1
        /// </summary>

        [SignOrder(7)]
        public string REMARK1 { get; set; }
        /// <summary>
        /// 备注1
        /// </summary>

        [SignOrder(8)]
        public string REMARK2 { get; set; }
        /// <summary>
        /// 0或空：返回页面二维码
        /// 1：返回JSON格式【二维码信息串】
        /// 2：返回聚合扫码页面二维码
        /// 3：返回聚合扫码JSON格式【二维码信息串】
        /// 聚合扫码只能上送2或3
        /// </summary>

        [SignOrder(9)]
        public EnumReturnType RETURNTYPE { get; set; }
        /// <summary>
        /// 格式：YYYYMMDDHHMMSS如：20120214143005 银行系统时间> TIMEOUT时拒绝交易，若送空值则不判断超时。
        /// </summary>
        [SignOrder(10)]
        public DateTime? TIMEOUT { get; set; }

        protected static PropertyInfo[] PropertyInfos = typeof(CCBPrePayRequest).GetProperties();


        public int Compare(string x, string y)
        {
            SignOrderAttribute signOrderAttributeX = GetSignOrderAttribute(x);
            SignOrderAttribute signOrderAttributeY = GetSignOrderAttribute(y);
            if (signOrderAttributeY == null)
            {
                return 1;
            }
            if (signOrderAttributeX == null)
            {
                return -1;
            }

            return signOrderAttributeX.Order - signOrderAttributeY.Order;
        }

        public SignOrderAttribute GetSignOrderAttribute(string key)
        {
            return PropertyInfos.FirstOrDefault(p =>p.GetCustomAttribute<WebApiClient.DataAnnotations.AliasAsAttribute>()?.Name == key || p.Name == key)
                ?.GetCustomAttribute<SignOrderAttribute>();
        }


    }
}
