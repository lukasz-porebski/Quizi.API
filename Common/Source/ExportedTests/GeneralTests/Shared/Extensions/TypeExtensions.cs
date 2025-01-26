namespace Common.GeneralTests.Shared.Extensions;

internal static class TypeExtensions
{
    public static bool HasOneAndPublicConstructor(this Type source) =>
        source.GetConstructors().Length == 1 && source.GetConstructors().All(c => c.IsPublic);
}