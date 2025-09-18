using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Common.Shared.DataStructures;

public class UniqueCollection<TKey, TValue> : IReadOnlyUniqueCollection<TKey, TValue>
    where TKey : notnull
    where TValue : notnull
{
    private readonly Dictionary<TKey, TValue> _values;

    public UniqueCollection(Func<TValue, TKey> keyPointer, IEnumerable<TValue> values)
        : this()
    {
        KeyPointer = keyPointer;

        foreach (var value in values)
        {
            var key = KeyPointer.Invoke(value);
            if (!_values.TryAdd(key, value))
                throw new ArgumentException($"Key {key} is already added");
        }
    }

    public UniqueCollection(Func<TValue, TKey> keyPointer)
        : this(keyPointer, [])
    {
    }

    private UniqueCollection()
    {
        KeyPointer = _ => default!;
        _values = new Dictionary<TKey, TValue>();
    }

    public Func<TValue, TKey> KeyPointer { get; }
    public int Count => _values.Count;
    public bool IsReadOnly => false;
    public IEnumerable<TValue> Values => _values.Values;

    public void Add(TValue value) =>
        _values.Add(KeyPointer(value), value);

    public void Clear() =>
        _values.Clear();

    public bool ContainsKey(TKey key) =>
        _values.ContainsKey(key);

    public bool Contains(TValue value) =>
        _values.ContainsKey(KeyPointer(value));

    public void CopyTo(TValue[] array, int arrayIndex) =>
        _values.Values.CopyTo(array, arrayIndex);

    public bool Remove(TValue item)
    {
        var key = KeyPointer(item);
        return _values.Remove(key);
    }

    public IEnumerator<TValue> GetEnumerator() =>
        _values.Values.GetEnumerator();

    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value) =>
        _values.TryGetValue(key, out value);

    public void AddMany(IEnumerable<TValue> values)
    {
        foreach (var value in values)
            Add(value);
    }

    public void RemoveMany(IEnumerable<TValue> values)
    {
        foreach (var value in values)
            _values.Remove(KeyPointer(value));
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();
}