using System;

namespace TONPlay {
    [Serializable]
    public class Token {
        public string address;
        public string name;
        public string description;
        public string image;
        public ulong? quantity;
        public ulong supply;
        public ulong index;
        public string type;
        public string? rarity;
        public string? category;
        public Social social;
        public Game game;
        public Market market;
        public Properties properties;
    }
}
