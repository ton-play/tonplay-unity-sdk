using System;
using System.Collections.Generic;

namespace TONPlay {
    [Serializable]
    public class Market {
        public List<Seller> sellers;
        public ulong quantityOnSale;
    }
}
