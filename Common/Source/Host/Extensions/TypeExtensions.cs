namespace Common.Host.Extensions;

public static class TypeExtensions
{
    public static bool IsRegistrable(this Type source) =>
        source is { IsAbstract: false, IsClass: true } &&
        source.GetConstructors().Any(c => c.IsPublic);

    public static bool Implements<T>(this Type source) =>
        source.Implements(typeof(T));

    public static bool Implements(this Type source, Type interfaceType) =>
        source.IsAssignableTo(interfaceType);

    public static bool ImplementsGeneric(this Type source, Type interfaceType) =>
        source.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);
}