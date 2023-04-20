using System;

namespace TONPlay {
    [Serializable]
    public class Game {
        public string key;
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? name;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? image;
    }
}
