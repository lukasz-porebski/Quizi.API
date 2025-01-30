namespace Common.Shared.Utils;

public interface IHasher
{
    public string Hash(string value, string? salt = null);
    public bool Verify(string hashedValue, string providedValue);
}