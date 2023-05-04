using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TONPlay.Example {
    [CreateAssetMenu(fileName = "TPayData", menuName = "TonPlayExample/TPayData", order = 2)]
    public class TPayData : ScriptableObject {
        [Header("Pay In Order")]
        //https://docs.tonplay.io/payment-solution/pay-in
        [Tooltip("Key for working with payment solution. Available in TON Play console")]
        public string PaymentKey;
        [Tooltip("External order id in the merchants system (any of your format). This is necessary so that you yourself can distinguish between transactions   ")]
        public string OrderId;
        [Tooltip("Value in $TON. Not $nanoTON")]
        public double Amount;
    }
}