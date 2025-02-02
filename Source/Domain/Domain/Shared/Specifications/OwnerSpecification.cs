using Common.Domain.Specification;
using Domain.Shared.Constants;
using Domain.Shared.Interfaces;

namespace Domain.Shared.Specifications;

internal class OwnerSpecification : ISpecification<IOwnerSpecification>
{
    public string FailureMessageCode => SharedMessageCodes.AccessDenied;

    public bool IsValid(IOwnerSpecification data) =>
        data.OwnerId.Equals(data.UserId);
}