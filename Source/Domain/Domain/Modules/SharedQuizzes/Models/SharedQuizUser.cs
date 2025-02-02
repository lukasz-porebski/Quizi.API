using Common.Domain.Entities;
using Common.Domain.ValueObjects;

namespace Domain.Modules.SharedQuizzes.Models;

public class SharedQuizUser : BaseEntity
{
    internal SharedQuizUser(AggregateId id, EntityNo no, AggregateId userId) : base(id, no)
    {
        UserId = userId;
    }

    private SharedQuizUser()
    {
    }

    public AggregateId UserId { get; private set; } = null!;
}