using System;
using System.Collections.Generic;

namespace TONPlay {
    [Serializable]
    public class PageableContent<T> {
        public List<T> content;
        public Page pageable;

        [Serializable]
        public class Page {
            public uint number;
            public uint size;
            public uint total;
            public bool last;
            public uint count;
        }
    }
}
