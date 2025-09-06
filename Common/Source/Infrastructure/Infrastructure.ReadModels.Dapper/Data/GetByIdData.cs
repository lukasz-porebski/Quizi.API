using Common.Domain.ValueObjects;

namespace Common.Infrastructure.ReadModels.Dapper.Data;

public record GetByIdData
{
    public GetByIdData(AggregateId id)
    {
        Id = id.ToString();
    }

    public string Id { get; }
};