using System;

namespace TONPlay {
    [Serializable]
    public class Token {
        public string address;
        public string name;
        public string description;
        public string image;
        public ulong quantity;
        public ulong supply;
        public ulong index;
        public string type;
        public Market market;
        public Properties properties;
    }
}
