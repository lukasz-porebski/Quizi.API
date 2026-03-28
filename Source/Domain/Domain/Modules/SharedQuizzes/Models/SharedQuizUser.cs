using LP.Common.Domain.Entities;
using LP.Common.Domain.ValueObjects;

namespace Domain.Modules.SharedQuizzes.Models;

public class SharedQuizUser : BaseEntityCore
{
    internal SharedQuizUser(AggregateId id, AggregateId userId) : base(id)
    {
        UserId = userId;
    }

    private SharedQuizUser()
    {
    }

    public AggregateId UserId { get; private set; } = null!;
}