using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TONPlay {
    public partial class TonPlayAPI : BaseAPI {
        public const string X_AUTH_TON_PLAY_KEY = "X-Auth-Tonplay";
        public const string SERVER = "https://external.api.tonplay.io";
        public string XAuthTonplay { get; set; }
    }
}