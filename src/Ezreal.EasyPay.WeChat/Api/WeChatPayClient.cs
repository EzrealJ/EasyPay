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
    public class WeChatPayClient
    {
        public WeChatPayClient(IWeChatPayContract weChatPayContract)
        {
            WeChatPayContract = weChatPayContract ?? HttpApi.Resolve<IWeChatPayContract>();
        }

        public virtual IWeChatPayContract WeChatPayContract { get; protected set; }
        public virtual Func<WeChatOptions> GetDefaultWeChatOptions { get; set; } = () => WeChatOptions.DefaultInstance;

        /// <summary>
        /// 应用默认的微信配置
        /// <para>
        /// 当AppId和MchId未被提供时生效
        /// </para>
        /// </summary>
        /// <typeparam name="TWeChatPayRequest"></typeparam>
        /// <param name="weChatPayRequest"></param>
        /// <returns></returns>
        protected virtual TWeChatPayRequest ApplyDefaultWeChatOptions<TWeChatPayRequest>(TWeChatPayRequest weChatPayRequest)
            where TWeChatPayRequest : WeChatPayRequest
        {
            WeChatOptions defaultWeChatOptions = GetDefaultWeChatOptions();
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
            WeChatOptions defaultWeChatOptions = GetDefaultWeChatOptions();
            weChatSignSettings = weChatSignSettings ?? new WeChatSignSettings();
            weChatSignSettings.Key = weChatSignSettings.Key ?? defaultWeChatOptions.Key;
            weChatSignSettings.Secret = weChatSignSettings.Secret ?? defaultWeChatOptions.Secret;
            return weChatSignSettings;
        }

        /// <summary>
        /// 尝试从指定的工厂解析<see cref="IWeChatPayContract"/>
        /// </summary>
        /// <param name="factoryName"></param>
        /// <returns></returns>
        protected virtual IWeChatPayContract ResolveFromTargetFactory(string factoryName) => HttpApi.Resolve<IWeChatPayContract>(factoryName);


        public ITask<WeChatPayFacePayResponse> FacePay(
        WeChatPayFacePayRequest facePayRequest,
        WeChatSignSettings weChatSignSettings = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken))
        {
            ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultWeChatOptions(facePayRequest);
            WeChatPayContract = WeChatPayContract ?? ResolveFromTargetFactory(facePayRequest.MchId);
            return WeChatPayContract.FacePay(weChatSignSettings, facePayRequest, timeout, cancellationToken);
        }


        public ITask<WeChatPayFacePayQueryResponse> FacePayQuery(
        WeChatPayFacePayQueryRequest facePayQueryRequest,
        WeChatSignSettings weChatSignSettings = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken))
        {
            ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultWeChatOptions(facePayQueryRequest);
            WeChatPayContract = WeChatPayContract ?? ResolveFromTargetFactory(facePayQueryRequest.MchId);
            return WeChatPayContract.FacePayQuery(weChatSignSettings, facePayQueryRequest, timeout, cancellationToken);
        }


        public ITask<WeChatPayMicroPayResponse> FacePay(
        WeChatPayMicroPayRequest microPayRequest,
        WeChatSignSettings weChatSignSettings = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken))
        {
            
            ApplyDefaultSignSettings(weChatSignSettings);
            ApplyDefaultWeChatOptions(microPayRequest);
            WeChatPayContract = WeChatPayContract ?? ResolveFromTargetFactory(microPayRequest.MchId);
            return WeChatPayContract.MicroPay(weChatSignSettings, microPayRequest, timeout, cancellationToken);
        }


    }
}
