namespace Ezreal.EasyPay.MergeChannels.CCB
{
    public class CCBPayOptions
    {
        public static CCBPayOptions DefaultInstance { get; internal set; } = new CCBPayOptions();

        /// <summary>
        /// 商户代码
        /// </summary>
        public string MerchantId { get; set; }
        /// <summary>
        /// 柜台代码
        /// </summary>
        public string PosId { get; set; }

        /// <summary>
        /// 分行代码
        /// </summary>
        public string BranchId { get; set; }
        public string Last30BitsOfPublicKey { get;  set; }
    }
}
