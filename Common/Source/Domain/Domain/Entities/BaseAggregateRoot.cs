using Common.Domain.ValueObjects;

namespace Common.Domain.Entities;

public abstract class BaseAggregateRoot : IEquatable<BaseAggregateRoot>
{
    private const int InitialVersion = 1;

    protected BaseAggregateRoot(AggregateId id)
    {
        Id = id;
    }

    protected BaseAggregateRoot() : this(null!)
    {
    }

    public AggregateId Id { get; }
    public AggregateStateChangeInfo CreationInto { get; private set; } = AggregateStateChangeInfo.Empty;
    public AggregateStateChangeInfo? UpdateInfo { get; private set; }
    public AggregateStateChangeInfo? RemovalInfo { get; private set; }
    public int Version { get; private set; } = InitialVersion;

    internal void Init(AggregateStateChangeInfo info)
    {
        if (!CreationInto.IsEmpty || Version != InitialVersion)
            throw new Exception("Aggregate is already initialized.");

        CreationInto = info;
    }

    internal void Update(AggregateStateChangeInfo info)
    {
        if (CreationInto.IsEmpty)
            throw new Exception("Aggregate must be initialized.");

        UpdateInfo = info;
        Version += 1;
    }

    internal void Remove(AggregateStateChangeInfo info)
    {
        if (RemovalInfo is not null)
            throw new Exception("Aggregate is already removed.");

        RemovalInfo = info;
    }

    #region Boilerplate

    public bool Equals(BaseAggregateRoot? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return obj.GetType() == GetType() && Equals((BaseAggregateRoot)obj);
    }

    public override int GetHashCode() =>
        Id.GetHashCode();

    public static bool operator ==(BaseAggregateRoot? left, BaseAggregateRoot? right) =>
        Equals(left, right);

    public static bool operator !=(BaseAggregateRoot? left, BaseAggregateRoot? right) =>
        !Equals(left, right);

    #endregion
}