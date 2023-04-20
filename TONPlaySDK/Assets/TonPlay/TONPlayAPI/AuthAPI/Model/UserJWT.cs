///
/// More info about UserJWT
/// https://docs.tonplay.io/digital-assets-api/authentication/about-jwt
///

using System;
using System.Collections.Generic;

namespace TONPlay {
    [Serializable]
    public class UserJWT {
        // TON Play user id
        public string sub;

        public string wallet;
        public string iss;
        public string token_type;
        public string team_key;
        public List<string> authorities;
        public string telegramId;
        public bool isTest;
        public string gameKey;
        public ulong exp;
        public ulong iat;
        //telegram username
        public string username;
    }
}
