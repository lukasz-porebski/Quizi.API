using Common.Shared.Utils;

namespace Common.Host.Utils;

public class Hasher : IHasher
{
    public string Hash(string value, string? salt = null) =>
        BCrypt.Net.BCrypt.HashPassword(value, salt: salt);

    public bool Verify(string hashedValue, string providedValue) =>
        BCrypt.Net.BCrypt.Verify(providedValue, hashedValue);
}