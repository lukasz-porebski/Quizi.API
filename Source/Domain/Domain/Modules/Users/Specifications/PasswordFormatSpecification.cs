using Common.Domain.Specification;
using Domain.Modules.Users.Constants;
using Domain.Modules.Users.Data;

namespace Domain.Modules.Users.Specifications;

internal class PasswordFormatSpecification : ISpecification<UserCreationData>
{
    public string FailureMessageCode => UserMessageCodes.IncorrectPasswordFormat;

    public bool IsValid(UserCreationData data) =>
        data.Password.Any() &&
        ContainsLowercaseLetter(data.Password) &&
        ContainsUppercaseLetter(data.Password) &&
        ContainsNumber(data.Password) &&
        ContainsSpecialCharacter(data.Password) &&
        !ContainsWhiteSpace(data.Password) &&
        MinLength(data.Password) &&
        MaxLength(data.Password);

    private static bool ContainsLowercaseLetter(string password) =>
        password.Any(char.IsLower);

    private static bool ContainsUppercaseLetter(string password) =>
        password.Any(char.IsUpper);

    private static bool ContainsNumber(string password) =>
        password.Any(char.IsNumber);

    private static bool ContainsSpecialCharacter(string password)
    {
        var specialCharacters = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~".ToCharArray();
        return password.Any(p => specialCharacters.Contains(p));
    }

    private static bool ContainsWhiteSpace(string password) =>
        password.Any(char.IsWhiteSpace);

    private static bool MinLength(string password) =>
        password.Length >= 10;

    private static bool MaxLength(string password) =>
        password.Length <= UserConstants.MaxPasswordLength;
}