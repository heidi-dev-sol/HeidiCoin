namespace HeidiCoin.Core.Models.References.Contracts;

public interface ICanBeHashed
{
    byte[] GetComputableSignature();
}