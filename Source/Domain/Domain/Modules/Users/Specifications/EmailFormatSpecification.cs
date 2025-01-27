using System.ComponentModel.DataAnnotations;
using Common.Domain.Specification;
using Domain.Modules.Users.Constants;
using Domain.Modules.Users.Data;

namespace Domain.Modules.Users.Specifications;

internal class EmailFormatSpecification : ISpecification<UserCreationData>
{
    public string FailureMessageCode => UserMessageCodes.IncorrectEmailFormat;

    public bool IsValid(UserCreationData data) =>
        new EmailAddressAttribute().IsValid(data.Email);
}