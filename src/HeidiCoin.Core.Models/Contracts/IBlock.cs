using HeidiCoin.Core.Models.References.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeidiCoin.Core.Models.Contracts
{
    public interface IBlock: ICanBeHashed
    {
        public long Index { get;  }
        public string PreviousHash { get; }
        public DateTime Timestamp { get; }
        public ICollection<ITransaction> Transactions { get; }
        public string Hash { get; set; }
        public long Nonce { get; set; }
    }
}
