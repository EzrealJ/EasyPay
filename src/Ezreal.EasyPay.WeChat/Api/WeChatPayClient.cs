using Ezreal.EasyPay.WeChat.ApiContract;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Request;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Response;
using Ezreal.EasyPay.WeChat.Sign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiClient;

namespace Ezreal.EasyPay.WeChat.Api
{
    /// <summary>
    /// 微信支付Client
    /// </summary>
    public class WeChatPayClient
    {


        public virtual IWeChatPayContract WeChatPayContract { get; protected set; }

        public virtual IWeChatPayAuthContract WeChatPayAuthContract { get; protected set; }
        public virtual Func<WeChatPayOptions> GetDefaultWeChatOptions { get; set; } = () => WeChatPayOptions.DefaultInstance;

        /// <summary>
        /// 应用默认的商户配置
        /// <para>
        /// 当AppId和MchId未被提供时生效
        /// </para>
        /// </summary>
        /// <typeparam name="TWeChatPayRequest"></typeparam>
        /// <param name="weChatPayRequest"></param>
        /// <returns></returns>
        protected virtual TWeChatPayRequest ApplyDefaultMerchantSettings<TWeChatPayRequest>(TWeChatPayRequest weChatPayRequest)
            where TWeChatPayRequest : WeChatPayRequest
        {
            if (weChatPayRequest == null)
            {
                throw new ArgumentNullException(nameof(weChatPayRequest));
            }

            WeChatPayOptions defaultWeChatOptions = GetDefaultWeChatOptions();
            weChatPayRequest.AppId = weChatPayRequest.AppId ?? defaultWeChatOptions.AppId;
            weChatPayRequest.MchId = weChatPayRequest.MchId ?? defaultWeChatOptions.MchId;
            return weChatPayRequest;
        }
        /// <summary>
        /// 应用默认的签名配置
        /// <para>
        /// 当签名配置未被提供时生效
        /// </para>
        /// </summary>
        /// <param name="weChatSignSettings"></param>
        /// <returns></returns>
        protected virtual WeChatSignSettings ApplyDefaultSignSettings(WeChatSignSettings weChatSignSettings)
        {
            WeChatPayOptions defaultWeChatOptions = GetDefaultWeChatOptions();
            weChatSignSettings = weChatSignSettings ?? new WeChatSignSettings();
            weChatSignSettings.Key = weChatSignSettings.Key ?? defaultWeChatOptions.Key;
            weChatSignSettings.Secret = weChatSignSettings.Secret ?? defaultWeChatOptions.Secret;
            return weChatSignSettings;
        }

        /// <summary>
        /// 尝试从指定的商户工厂解析<see cref="IWeChatPayContract"/>
        /// </summary>
        /// <param name="merchantId">商户号</param>
        /// <returns></returns>
        protected virtual TContract ResolveFromTargetMerchantFactory<TContract>(string merchantId) where TContract : class, IHttpApi => HttpApi.Resolve<TContract>($"{merchantId}_{typeof(TContract).Name}");


        public ITask<WeChatPayMicroPayResponse> MicroPay(
        WeChatPayMicroPayRequest microPayRequest,
        WeChatSignSettings weChatSignSettings = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken))
        {
            weChatSignSettings = ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultMerchantSettings(microPayRequest);
            WeChatPayContract = WeChatPayContract ?? ResolveFromTargetMerchantFactory<IWeChatPayContract>(microPayRequest.MchId);
            return WeChatPayContract.MicroPay(weChatSignSettings, microPayRequest, timeout, cancellationToken);
        }


        public ITask<WeChatPayFacePayAuthResponse> FacePayAuth(
        WeChatPayFacePayAuthRequest facePayAuthRequest,
        WeChatSignSettings weChatSignSettings = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken))
        {
            weChatSignSettings = ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultMerchantSettings(facePayAuthRequest);
            WeChatPayAuthContract = WeChatPayAuthContract ?? ResolveFromTargetMerchantFactory<IWeChatPayAuthContract>(facePayAuthRequest.MchId);
            return WeChatPayAuthContract.FacePayAuth(weChatSignSettings, facePayAuthRequest, timeout, cancellationToken);
        }
        public ITask<WeChatPayFacePayResponse> FacePay(
        WeChatPayFacePayRequest facePayRequest,
        WeChatSignSettings weChatSignSettings = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken))
        {
            weChatSignSettings = ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultMerchantSettings(facePayRequest);
            WeChatPayContract = WeChatPayContract ?? ResolveFromTargetMerchantFactory<IWeChatPayContract>(facePayRequest.MchId);
            return WeChatPayContract.FacePay(weChatSignSettings, facePayRequest, timeout, cancellationToken);
        }

        public ITask<WeChatPayOrderQueryResponse> OrderQuery(
        WeChatPayOrderQueryRequest orderQueryRequest,
        WeChatSignSettings weChatSignSettings = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
        {
            weChatSignSettings = ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultMerchantSettings(orderQueryRequest);
            WeChatPayContract = WeChatPayContract ?? ResolveFromTargetMerchantFactory<IWeChatPayContract>(orderQueryRequest.MchId);
            return WeChatPayContract.OrderQuery(weChatSignSettings, orderQueryRequest, timeout, cancellationToken);
        }
        public ITask<WeChatPayFacePayQueryResponse> FacePayQuery(
        WeChatPayFacePayQueryRequest facePayQueryRequest,
        WeChatSignSettings weChatSignSettings = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken))
        {
            weChatSignSettings = ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultMerchantSettings(facePayQueryRequest);
            WeChatPayContract = WeChatPayContract ?? ResolveFromTargetMerchantFactory<IWeChatPayContract>(facePayQueryRequest.MchId);
            return WeChatPayContract.FacePayQuery(weChatSignSettings, facePayQueryRequest, timeout, cancellationToken);
        }


        public ITask<WeChatPayFacePayReverseResponse> FacePayReverse(
        WeChatPayFacePayReverseRequest facePayReverseRequest,
        WeChatSignSettings weChatSignSettings = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken))
        {

            weChatSignSettings = ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultMerchantSettings(facePayReverseRequest);
            WeChatPayContract = WeChatPayContract ?? ResolveFromTargetMerchantFactory<IWeChatPayContract>(facePayReverseRequest.MchId);
            return WeChatPayContract.FacePayReverse(weChatSignSettings, facePayReverseRequest, timeout, cancellationToken);
        }


        public ITask<WeChatPayReverseResponse> Reverse(
        WeChatPayReverseRequest reverseRequest,
        WeChatSignSettings weChatSignSettings = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken))
        {

            weChatSignSettings = ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultMerchantSettings(reverseRequest);
            WeChatPayContract = WeChatPayContract ?? ResolveFromTargetMerchantFactory<IWeChatPayContract>(reverseRequest.MchId);
            return WeChatPayContract.Reverse(weChatSignSettings, reverseRequest, timeout, cancellationToken);
        }

        public ITask<WeChatPayRefundResponse> Refund(
          WeChatPayRefundRequest refundRequest,
           WeChatSignSettings weChatSignSettings = null,
          TimeSpan? timeout = null,
          CancellationToken cancellationToken = default(CancellationToken))
        {

            weChatSignSettings = ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultMerchantSettings(refundRequest);
            WeChatPayContract = WeChatPayContract ?? ResolveFromTargetMerchantFactory<IWeChatPayContract>(refundRequest.MchId);
            return WeChatPayContract.Refund(weChatSignSettings, refundRequest, timeout, cancellationToken);
        }


        public ITask<WeChatPayRefundQueryResponse> RefundQuery(
        WeChatPayRefundQueryRequest refundQueryRequest,
         WeChatSignSettings weChatSignSettings = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken))
        {
            weChatSignSettings = ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultMerchantSettings(refundQueryRequest);
            WeChatPayContract = WeChatPayContract ?? ResolveFromTargetMerchantFactory<IWeChatPayContract>(refundQueryRequest.MchId);
            return WeChatPayContract.RefundQuery(weChatSignSettings, refundQueryRequest, timeout, cancellationToken);
        }
    }
}
