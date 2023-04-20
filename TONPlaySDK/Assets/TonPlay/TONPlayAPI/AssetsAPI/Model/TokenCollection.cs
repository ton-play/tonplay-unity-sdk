using System;

namespace TONPlay {
    [Serializable]
    public class TokenCollection {
        public string name;
        public string avatar;
        public string address;
        public string? description;
        public Profile ownerProfile;
        public ulong size;
    }
}