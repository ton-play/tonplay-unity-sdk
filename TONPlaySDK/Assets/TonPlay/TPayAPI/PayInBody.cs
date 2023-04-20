using System;

namespace TONPlay {
    [Serializable]
    public class PayInBody {
        //any id needed to distinguish requests from each other
        public string orderId;
        //amount in TON
        public double amount;
    }
}
