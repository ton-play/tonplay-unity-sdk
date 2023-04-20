using System;

namespace TONPlay {
    [Serializable]
    public class BuyAssetBody {
        public string address;
        public ulong amount;
        public string type;
        public string buyerAddress;
        public string sellerAddress;
    }
}
