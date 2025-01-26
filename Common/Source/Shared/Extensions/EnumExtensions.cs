namespace Common.Shared.Extensions;

public static class EnumExtensions
{
    public static string ValueToString<T>(this T value)
        where T : Enum =>
        ((int)(object)value).ToString();
}