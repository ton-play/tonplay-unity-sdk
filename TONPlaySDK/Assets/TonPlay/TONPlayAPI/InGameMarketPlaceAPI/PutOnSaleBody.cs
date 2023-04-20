using System;

namespace TONPlay {
    [Serializable]
    public class PutOnSaleBody {
        public string address;
        public string price;
        public ulong amount;
        public string type;
        public string sellerAddress;
    }
}
