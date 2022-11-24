namespace SpectacledBear.Cryptography.Hash;

public interface IHashCalculator
{
    string CalculateHash(Stream stream);
}
