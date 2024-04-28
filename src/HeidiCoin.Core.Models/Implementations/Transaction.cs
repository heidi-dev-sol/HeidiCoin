namespace HeidiCoin.Core.Models.Implementations;

using System.Text;
using HeidiCoin.Core.Models.Contracts;

public class Transaction(string sender, string recipient, decimal amount, string? data = null)
    : ITransaction
{
    public byte[] GetComputableSignature()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendJoin('*', this.Sender);
        stringBuilder.AppendJoin('*', this.Recipient);
        stringBuilder.AppendJoin('*', this.Amount);
        stringBuilder.AppendJoin('*', this.Timestamp);

        if (!string.IsNullOrEmpty(this.Data))
            stringBuilder.AppendJoin('*', this.Data);

        return Encoding.UTF32.GetBytes(stringBuilder.ToString());
    }

    public string Sender { get; } = sender;
    public string Recipient { get; } = recipient;
    public decimal Amount { get; } = amount;
    public DateTime Timestamp { get; } = DateTime.UtcNow;
    public string? Data { get; } = data;
}