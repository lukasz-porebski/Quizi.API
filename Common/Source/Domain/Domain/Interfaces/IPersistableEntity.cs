using Common.Domain.ValueObjects;

namespace Common.Domain.Interfaces;

public interface IPersistableEntity
{
    EntityNo? No { get; }
}