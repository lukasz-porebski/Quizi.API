using Domain.Modules.Roles.Constants;
using Domain.Modules.Roles.Data;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Roles.Specifications;

internal class RoleNameSpecification : ISpecification<RoleCreationData>
{
    public string FailureMessageCode => RoleMessageCodes.RoleNameLengthIsOutOfRange;

    public bool IsValid(RoleCreationData data) =>
        data.Name.Length is >= 1 and <= RoleConstants.MaxNameLength;
}