using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using Ezreal.EasyPay.MergeChannels.CCB.ApiContract;
using Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Request;
using Ezreal.EasyPay.MergeChannels.CCB.Sign;
using WebApiClient;

namespace Ezreal.EasyPay.MergeChannels.CCB.Api
{
    public class CCBPayClient
    {

        public virtual ICCBPayContract CCBPayContract { get; protected set; }
        public virtual Func<CCBPayOptions> GetDefaultCCBOptions { get; set; } = () => CCBPayOptions.DefaultInstance;

        /// <summary>
        /// 应用默认的商户配置
        /// <para>
        /// 当MerchantId、PosId、BranchId未被提供时生效
        /// </para>
        /// </summary>
        /// <typeparam name="TCCBPayRequest"></typeparam>
        /// <returns></returns>
        protected virtual TCCBPayRequest ApplyDefaultMerchantSettings<TCCBPayRequest>(TCCBPayRequest payRequest)
            where TCCBPayRequest : CCBPayRequest
        {
            if (payRequest == null)
            {
                throw new ArgumentNullException(nameof(payRequest));
            }

            CCBPayOptions defaultWeChatOptions = GetDefaultCCBOptions();
            payRequest.MerchantId = payRequest.MerchantId ?? defaultWeChatOptions.MerchantId;
            payRequest.PosId = payRequest.PosId ?? defaultWeChatOptions.PosId;
            payRequest.BranchId = payRequest.BranchId ?? defaultWeChatOptions.BranchId;
            return payRequest;
        }
        /// <summary>
        /// 应用默认的签名配置
        /// <para>
        /// 当签名配置未被提供时生效
        /// </para>
        /// </summary>
        /// <param name="ccbSignSettings"></param>
        /// <returns></returns>
        protected virtual CCBSignSettings ApplyDefaultSignSettings(CCBSignSettings ccbSignSettings)
        {
            CCBPayOptions defaultCCBOptions = GetDefaultCCBOptions();
            ccbSignSettings = ccbSignSettings ?? new CCBSignSettings();
            ccbSignSettings.Last30BitsOfPublicKey = ccbSignSettings.Last30BitsOfPublicKey ?? defaultCCBOptions.Last30BitsOfPublicKey;
            return ccbSignSettings;
        }

        /// <summary>
        /// 尝试从指定的商户工厂解析接口协议
        /// </summary>
        /// <returns></returns>
        protected virtual TContract ResolveFromDefaultFactory<TContract>() where TContract : class, IHttpApi => HttpApi.Resolve<TContract>();

        public ITask<HttpResponseMessage> PrePay(CCBPrePayRequest prePayRequest, CCBSignSettings signSettings = null,
  TimeSpan? timeout = null,
 CancellationToken cancellationToken = default)
        {
            signSettings = ApplyDefaultSignSettings(signSettings);
            ApplyDefaultMerchantSettings(prePayRequest);
            CCBPayContract = CCBPayContract ?? ResolveFromDefaultFactory<ICCBPayContract>();
            return CCBPayContract.PrePay(signSettings, prePayRequest, timeout, cancellationToken);
        }
    }
}
