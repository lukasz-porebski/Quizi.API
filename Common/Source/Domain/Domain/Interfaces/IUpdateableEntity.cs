using Common.Domain.ValueObjects;

namespace Common.Domain.Interfaces;

public interface IUpdateableEntity
{
    EntityNo No { get; }
}