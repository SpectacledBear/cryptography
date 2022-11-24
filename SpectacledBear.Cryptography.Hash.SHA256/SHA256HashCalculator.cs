using DotNetSHA256 = System.Security.Cryptography.SHA256;

namespace SpectacledBear.Cryptography.Hash.SHA256;

public class SHA256HashCalculator : IHashCalculator
{
    public string CalculateHash(Stream stream)
    {
        // From https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.sha256?view=net-6.0
        
        using var sha256 = DotNetSHA256.Create();

        if (stream.CanSeek)
        {
            stream.Position = 0;
        }

        var hashValues = sha256.ComputeHash(stream);

        var hashValue = string.Join("", hashValues.Select(b => b.ToString("X2"))).ToLower();
        
        return hashValue;
    }
}
