using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TONPlay.Example {
    [CreateAssetMenu(fileName = "TPayData", menuName = "TonPlayExample/TPayData", order = 2)]
    public class TPayData : ScriptableObject {

        [Header("New merchant data")]
        //https://docs.tonplay.io/payment-solution/create-merchant
        [Tooltip("Your merchant name")]
        public string Name;
        [Tooltip("merchant’s TON wallet address in base64 user friendly format")]
        public string Address;
        [Tooltip("complete URL on the merchant’s side, which can receive POST requests and is publicly available")]
        //only for test you can use https://webhook.site/
        public string Webhook;

        [Header("Pay In Order")]
        //https://docs.tonplay.io/payment-solution/pay-in

        [Tooltip("external order id in the merchant’s system (any of your format)")]
        public string OrderId;
        [Tooltip("value in $TON")]
        public double Amount;
    }
}