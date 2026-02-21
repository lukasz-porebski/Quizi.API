using System.Text.RegularExpressions;
using Common.Domain.Specification;
using Domain.Modules.Users.Constants;
using Domain.Modules.Users.Data;

namespace Domain.Modules.Users.Specifications;

internal class EmailFormatSpecification : ISpecification<UserCreationData>
{
    public string FailureMessageCode => UserMessageCodes.IncorrectEmailFormat;

    public bool IsValid(UserCreationData data)
    {
        const string pattern =
            @"^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)" +
            @"*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$";
        return Regex.IsMatch(data.Email, pattern);
    }
}