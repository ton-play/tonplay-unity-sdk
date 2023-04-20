using System;

namespace TONPlay {
    [Serializable]
    public class User {
        //username  on TON Play
        public string username;
        //identifier on TON Play
        public string identifier;
        public ulong created;
        public string avatar;
        public string? bio;
        public Wallet? wallet;
    }
}
