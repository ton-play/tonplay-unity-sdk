using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TONPlay.Example {
    [CreateAssetMenu(fileName = "TonPlayData", menuName = "TonPlayExample/TonPlayAPIData", order = 1)]
    public class TonPlayData : ScriptableObject {

        [Header("TON Play API")]
        [Tooltip("Your game API Key https://docs.tonplay.io/digital-assets-api/api-key ")]
        public string XAuthTonplay;

        [Tooltip("Your game Key https://docs.tonplay.io/digital-assets-api/api-key#gamekey ")]
        public string GameKey;

        [Tooltip("User JWT https://docs.tonplay.io/digital-assets-api/authentication")]
        public string UserJWT;
    }
}
