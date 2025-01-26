using System.Diagnostics.CodeAnalysis;

namespace Common.Shared.DataStructures;

public interface IReadOnlyUniqueCollection<TKey, TValue> : ICollection<TValue>
    where TKey : notnull
    where TValue : notnull
{
    Func<TValue, TKey> KeyPointer { get; }
    IEnumerable<TValue> Values { get; }
    bool ContainsKey(TKey key);
    bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value);
}