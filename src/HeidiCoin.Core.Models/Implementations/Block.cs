using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeidiCoin.Core.Models.Implementations
{
    using HeidiCoin.Core.Models.Contracts;

    //The main block class that represents a single block.
    public class Block<TData> : IBlock<TData>
    {
        public long Index { get; set; }
        public string PreviousHash { get; set; }
        public DateTime Timestamp { get; set; }
        public TData Data { get; set; }
        public string Hash { get; set; }
        public long Nonce { get; set; }
    }

    public class Block : Block<string>, IBlock { }
}
