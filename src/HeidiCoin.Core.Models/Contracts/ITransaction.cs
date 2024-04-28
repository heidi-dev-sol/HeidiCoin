namespace HeidiCoin.Core.Models.Contracts;

using HeidiCoin.Core.Models.References.Contracts;

public interface ITransaction : ITransaction<string?> { }

public interface ITransaction<out TData> : ICanBeHashed
{
    string Sender { get; }
    string Recipient { get; }
    decimal Amount { get;  }
    DateTime Timestamp { get;  }
    TData Data { get;  }
}