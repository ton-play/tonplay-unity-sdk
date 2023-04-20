using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TONPlay {
    public partial class TonPlayAPI : BaseAPI {

        public const string TON_PLAY_ADD_WALLET_LINK_PREFIX = "https://tonapi.io/login?app=085f941afd4dedddda03cc8708b17c3db6fd9acedf2593117debbc71019a047a353632&callback_url=https://web.api.tonplay.io/auth/v1/tonkeeper?uid=";

        public static string GetAddWalletLink(string uid) {
            return TON_PLAY_ADD_WALLET_LINK_PREFIX + uid;
        }
    }
}