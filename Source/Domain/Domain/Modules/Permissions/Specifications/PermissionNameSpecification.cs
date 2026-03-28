using Domain.Modules.Permissions.Constants;
using Domain.Modules.Permissions.Data;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Permissions.Specifications;

internal class PermissionNameSpecification : ISpecification<PermissionCreationData>
{
    public string FailureMessageCode => PermissionMessageCodes.PermissionNameLengthIsOutOfRange;

    public bool IsValid(PermissionCreationData data) =>
        data.Name.Length is >= 1 and <= PermissionConstants.MaxNameLength;
}