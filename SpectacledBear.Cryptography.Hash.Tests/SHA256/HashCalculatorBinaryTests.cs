using SpectacledBear.Cryptography.Hash.SHA256;

namespace SpectacledBear.Cryptography.Hash.Tests.SHA256;

public class HashCalculatorBinaryTests
{
    private const string TestImageFilename = "square-16x16.jpg";
    private const string TestImageHashValue = "30ffc139a039f6ce2933bad8871885e4cacea2f8792af7d6835c41962cb4a25c";

    [Test]
    public void Hash_Calculator_Can_Compute_A_HashValue_When_Stream_Position_Is_Zero()
    {
        Stream stream = CreateStreamFromImageFile(TestImageFilename);
        stream.Position = 0;

        IHashCalculator hashCalculator = new SHA256HashCalculator();
        string hashValue = hashCalculator.CalculateHash(stream);
        
        Assert.That(hashValue, Is.EqualTo(TestImageHashValue));
    }

    [Test]
    public void Hash_Calculator_Can_Compute_A_HashValue_When_Stream_Position_Is_Not_Zero()
    {
        Stream stream = CreateStreamFromImageFile(TestImageFilename);
        
        IHashCalculator hashCalculator = new SHA256HashCalculator();
        string hashValue = hashCalculator.CalculateHash(stream);
        
        Assert.That(hashValue, Is.EqualTo(TestImageHashValue));
    }

    [Test]
    public void Hash_Calculator_Value_Is_Lowercase()
    {
        var stream = CreateStreamFromImageFile(TestImageFilename);

        IHashCalculator hashCalculator = new SHA256HashCalculator();
        var hashValue = hashCalculator.CalculateHash(stream);
        
        Assert.That(hashValue, Is.EqualTo(hashValue.ToLower()));
    }

    private Stream CreateStreamFromImageFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file path \"{filePath}\" is not valid.");
        }

        return File.OpenRead(filePath);
    }
}
