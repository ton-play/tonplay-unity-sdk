using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TONPlay {
    public partial class TPayAPI : BaseAPI {
        public const string X_AUTH_TPAY_KEY = "X-Auth-TPay";
        public const string SERVER = "https://tpay.tonplay.io";
        public string XAuthTPay { get; set; }
    }
}