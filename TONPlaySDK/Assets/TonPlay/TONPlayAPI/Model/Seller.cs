using System;

namespace TONPlay {
    [Serializable]
    public class Seller {
        public string address;
        public string type;
        public double price;
        public double sellPrice;
        public Profile seller;
        public double serviceFee;
        public double royaltyFee;
        public ulong? quantity;
    }
}
