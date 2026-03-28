using System.Text.RegularExpressions;
using Domain.Modules.Users.Constants;
using Domain.Modules.Users.Data;
using LP.Common.Domain.Specification;

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