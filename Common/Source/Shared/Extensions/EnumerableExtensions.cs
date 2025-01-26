using Common.Shared.DataStructures;

namespace Common.Shared.Extensions;

public static class EnumerableExtensions
{
    public static bool IsEmpty<T>(this IEnumerable<T>? source) =>
        source == null || !source.Any();

    public static bool CollectionEqual<T>(this IEnumerable<T>? source, IEnumerable<T>? other)
    {
        if (source is null || other is null)
            return false;

        return new HashSet<T>(source).SetEquals(other);
    }

    public static bool ContainsDuplicates<T>(this IEnumerable<T> source)
    {
        var hashSet = new HashSet<T>();

        return source.Any(element => !hashSet.Add(element));
    }

    public static List<T> CreateList<T>(this IEnumerable<T>? source) =>
        source is null ? [] : source.ToList();

    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T>? source) =>
        source ?? [];

    public static bool NotExists<T>(this List<T> source, Predicate<T> match) =>
        !source.Exists(match);

    public static UniqueCollection<TKey, TValue> ToUniqueCollection<TKey, TValue>(
        this IEnumerable<TValue> source,
        Func<TValue, TKey> keyPointer)
        where TKey : notnull
        where TValue : notnull =>
        new(keyPointer, source);
}