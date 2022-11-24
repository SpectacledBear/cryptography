using System.Text;
using SpectacledBear.Cryptography.Hash.SHA256;

namespace SpectacledBear.Cryptography.Hash.Tests.SHA256;

public class HashCalculatorStringTests
{
    private const string TestString = "String to be hashed.";
    private const string TestStringHashValue = "290188d5b588a881456da2adc5238b37fff187aedae74ad63a40551544c94314";
    
    [Test]
    public void Hash_Calculator_Can_Compute_A_HashValue_When_Stream_Position_Is_Zero()
    {
        Stream stream = CreateStreamFromString(TestString);
        stream.Position = 0;

        IHashCalculator hashCalculator = new SHA256HashCalculator();
        string hashValue = hashCalculator.CalculateHash(stream);
        
        Assert.That(hashValue, Is.EqualTo(TestStringHashValue));
    }

    [Test]
    public void Hash_Calculator_Can_Compute_A_HashValue_When_Stream_Position_Is_Not_Zero()
    {
        Stream stream = CreateStreamFromString(TestString);
        
        IHashCalculator hashCalculator = new SHA256HashCalculator();
        string hashValue = hashCalculator.CalculateHash(stream);
        
        Assert.That(hashValue, Is.EqualTo(TestStringHashValue));
    }
    

    [Test]
    public void Hash_Calculator_Value_Is_Lowercase()
    {
        Stream stream = CreateStreamFromString(TestString);

        IHashCalculator hashCalculator = new SHA256HashCalculator();
        string hashValue = hashCalculator.CalculateHash(stream);
        
        Assert.That(hashValue, Is.EqualTo(hashValue.ToLower()));
    }

    [Test]
    public void Hash_Calculator_Uses_Default_Encoding()
    {
        byte[] byteArray = Encoding.Default.GetBytes(TestString);
        string newString = Encoding.Default.GetString(byteArray);
        Stream stream = CreateStreamFromString(newString);

        IHashCalculator hashCalculator = new SHA256HashCalculator();
        string hashValue = hashCalculator.CalculateHash(stream).ToLower();
        
        Assert.That(hashValue, Is.EqualTo(TestStringHashValue));
    }
    
    private Stream CreateStreamFromString(string value)
    {
        var stream = new MemoryStream();
        var stringWriter = new StreamWriter(stream);
        stringWriter.Write(value);
        stringWriter.Flush();

        return stream;
    }
}
