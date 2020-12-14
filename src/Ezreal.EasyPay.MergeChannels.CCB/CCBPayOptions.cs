namespace Ezreal.EasyPay.MergeChannels.CCB
{
    public class CCBPayOptions
    {
        private string _publicKey;

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
        public string Last30OfPublicKey { get; private set; }
        public string PublicKey
        {
            get => _publicKey;
            set
            {
                Last30OfPublicKey = value.Substring(value.Length - 30, 30);
                _publicKey = value;
            }
        }
    }
}
