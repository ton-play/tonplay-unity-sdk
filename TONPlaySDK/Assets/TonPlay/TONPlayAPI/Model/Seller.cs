using System;

namespace TONPlay {
    [Serializable]
    public class Seller {
        public string? address;
        public string? image;
        public string? name;
        public string? type;
        public double price;
        public Profile seller;
        public double serviceFee;
        public double royaltyFee;
        public ulong quantity;
    }
}
