using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.Attributes;
using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Notify
{
    public class CCBPrePayNotify
    {
        /// <summary>
        /// 商户代码
        /// </summary>
        [IgnoreSerialized]
        public string MERCHANTID { get; protected set; }
        /// <summary>
        /// 柜台代码
        /// </summary>
        [SignOrder(0)]
        public string POSID { get; set; }

        /// <summary>
        /// 分行代码
        /// </summary>
        [SignOrder(1)]
        public string BRANCHID { get; set; }
        /// <summary>
        /// 订单Id
        /// <para>
        /// 由商户提供，最长30位。需按以下规则生成订单号：商户代码(15位)+自定义字符串(不超过15位)。字符串可包含数字、字母、下划线。商户需保证订单号唯一。
        /// </para>
        /// </summary>
        [SignOrder(2)]
        public string ORDERID
        {
            get
            {
                if (string.IsNullOrWhiteSpace(MERCHANTID))
                {
                    throw new MemberAccessException($"{nameof(MERCHANTID)} not be null");
                }
                if (string.IsNullOrWhiteSpace(OrderIdSuffix))
                {
                    throw new MemberAccessException($"{nameof(OrderIdSuffix)} not be null");
                }
                if (MERCHANTID.Length != 15)
                {
                    throw new IndexOutOfRangeException($"length of {nameof(MERCHANTID)} must be 15");
                }
                return MERCHANTID + OrderIdSuffix;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new MemberAccessException($"{nameof(value)} not be null");
                }
                string orderIdPrefix = value.Substring(0, 15);
                if (orderIdPrefix != MERCHANTID)
                {
                    throw new MemberAccessException($"{ nameof(value) } prefix must be MerchantId");
                }
                OrderIdSuffix = value.Substring(15, value.Length - 15);
            }
        }
        /// <summary>
        /// 订单后缀
        /// </summary>
        [IgnoreSerialized]
        public string OrderIdSuffix { get; protected set; }
        /// <summary>
        /// 金额
        /// </summary>
        [SignOrder(3)]
        public decimal PAYMENT { get; set; }
        /// <summary>
        /// 货币代码
        /// </summary>
        [SignOrder(4)]
        public string CURCODE { get; set; } = "01";
        /// <summary>
        /// 备注1
        /// </summary>
        [SignOrder(6)]
        public string REMARK1 { get; set; }
        /// <summary>
        /// 备注2
        /// </summary>
        [SignOrder(7)]
        public string REMARK2 { get; set; }
        /// <summary>
        /// 账户类型
        /// </summary>
        [SignOrder(8)]
        public string ACC_TYPE { get; set; }
        /// <summary>
        /// 成功标志 Y/N
        /// </summary>
        [SignOrder(9)]
        public string SUCCESS { get; set; }
        /// <summary>
        /// 接口类型
        /// <para>分行业务人员在P2员工渠道后台设置防钓鱼的开关。
        ///开关关闭时，无此字段返回且不参与验签。
        ///开关打开时，有此字段返回且参与验签。参数值为
        ///1-防钓鱼接口
        ///</para>
        /// </summary>
        [SignOrder(10), IgnoreWhenNull]
        public int? TYPE { get; set; }
        /// <summary>
        /// Referer信息
        /// <para>
        /// 分行业务人员在P2员工渠道后台设置防钓鱼开关。
        /// 1.开关关闭时，无此字段返回且不参与验签。
        /// 2.开关打开时，有此字段返回且参与验签。
        /// </para>
        /// </summary>
        [SignOrder(11),IgnoreWhenNull]
        public string REFERER { get; set; }
        /// <summary>
        /// 客户端IP
        /// <para>
        ///分行业务人员在P2员工渠道后台设置防钓鱼的开关。
        ///1.开关关闭时，无此字段返回且不参与验签。
        ///2.开关打开时，有此字段返回且参与验签。参数值为
        ///客户在建行系统中的IP
        /// </para>
        /// </summary>
        [SignOrder(12), IgnoreWhenNull] public string CLIENTIP { get; set; }
        /// <summary>
        /// 系统记账日期
        /// <para>商户登陆商户后台设置返回记账日期的开关
        ///1.开关关闭时，无此字段返回且不参与验签。
        ///2.开关打开时，有此字段返回且参与验签。参数值格式为YYYYMMDD（如20100907）。</para>
        /// </summary>
        [SignOrder(13), IgnoreWhenNull] public string ACCDATE { get; set; }
        /// <summary>
        /// 支付账户信息
        /// <para>
        /// 分行业务人员在P2员工渠道后台设置防钓鱼开关和返回账户信息的开关。
        ///1.开关关闭时，无此字段返回且不参与验签。
        ///2.开关打开但支付失败时，无此字段返回且不参与验签。
        ///3.开关打开且支付成功时，有此字段返回且参与验签。无PAYTYPE返回时，参数值格式如下：“姓名|账号加密后的密文”。有PAYTYPE返回时，该参数值为空。
        /// </para>
        /// </summary>
        [SignOrder(14), IgnoreWhenNull] public string USRMSG { get; set; }
        /// <summary>
        /// 客户加密信息
        /// <para>
        ///分行业务人员在P2员工渠道后台设置防钓鱼开关和客户信息加密返回的开关。
        ///1.开关关闭时，无此字段返回且不参与验签
        ///2.开关打开时，有此字段返回且参数验签。无PAYTYPE返回时，参数值格式如下：“证件号密文|手机号密文”。该字段不可解密。有PAYTYPE返回时，该参数值为空。
        /// </para>
        /// </summary>
        [SignOrder(15), IgnoreWhenNull] public string USRINFO { get; set; }
        /// <summary>
        /// 支付方式
        /// <para>
        ///ALIPAY:支付宝
        ///WEIXIN：微信
        ///为空：建行龙支付
        ///该字段有返回时参与验签，无此字段返回时不参与验签。
        /// </para>
        /// </summary>
        [SignOrder(16), IgnoreWhenNull] public string PAYTYPE { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string SIGN { get; set; }




    }
}
