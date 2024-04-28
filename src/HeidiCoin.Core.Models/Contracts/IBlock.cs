using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeidiCoin.Core.Models.Contracts
{
    public interface IBlock : IBlock<string> { }

    public interface IBlock<TData>
    {
        public long Index { get; set; }
        public string PreviousHash { get; set; }
        public DateTime Timestamp { get; set; }
        public TData Data { get; set; }
        public string Hash { get; set; }
        public long Nonce { get; set; }
    }
}
