namespace HeidiCoin.Core.Models.Implementations;

using System.Text;
using HeidiCoin.Core.Models.Contracts;

//The main block class that represents a single block.
public class Block(long index, string previousHash) : IBlock
{
    public long Index { get; } = index;
    public string PreviousHash { get; } = previousHash;
    public DateTime Timestamp { get; } = DateTime.UtcNow;
    public ICollection<ITransaction> Transactions { get; } = new List<ITransaction>();
    public string Hash { get; set; }
    public long Nonce { get; set; }

    public byte[] GetComputableSignature()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendJoin('*', this.Index);
        stringBuilder.AppendJoin('*', this.PreviousHash);

        foreach (var transaction in this.Transactions)
            //TODO: Test this to ensure it is recreatable
            stringBuilder.AppendJoin('*', transaction.GetComputableSignature());

        stringBuilder.AppendJoin('*', this.Timestamp);

        return Encoding.UTF32.GetBytes(stringBuilder.ToString());
    }
}