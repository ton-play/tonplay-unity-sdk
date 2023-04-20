using System;

namespace TONPlay {
    [Serializable]
    public class Properties {
        public string category;
        public string owner;
        public Profile ownerProfile;
        public TokenCollection collection;
        public string attributes;
    }
}
