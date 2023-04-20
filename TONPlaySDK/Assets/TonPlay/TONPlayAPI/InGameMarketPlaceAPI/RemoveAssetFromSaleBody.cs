using System;

namespace TONPlay {
    [Serializable]
    public class RemoveAssetFromSaleBody {
        public string address;
        public ulong amount;
        public string type;
        public string sellerAddress;
    }
}
