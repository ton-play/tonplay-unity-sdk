using System;
using System.Collections.Generic;

namespace TONPlay {
    [Serializable]
    public class Market {
        
        public enum Status {
            ON_SALE
        }

        public string status;
        public bool isOwner;
        public double price;
        public double sellPrice;
        public Profile seller;
        public Fee fee;
        public bool notForSale;
        public ulong availableForBuy;
        public ulong mySellingCount;
        public List<Seller> sellers;
    }
}
