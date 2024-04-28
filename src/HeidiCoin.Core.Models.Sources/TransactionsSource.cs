namespace HeidiCoin.Core.Models.Sources
{
    using HeidiCoin.Core.Models.Contracts;
    using HeidiCoin.Core.Models.Implementations;

    public static class TransactionsSource
    {
        public static ITransaction CreateDefaultTransaction => TransactionsSource.CreateTransaction("0x01", "0x02", 100.0m);

        public static ITransaction CreateTransaction(string sender, string receiver, decimal amount) =>
            new Transaction(sender, receiver, amount);
    }
}
