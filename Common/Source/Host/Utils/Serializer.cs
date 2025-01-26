using Newtonsoft.Json;

namespace Common.Host.Utils;

public static class Serializer
{
    public static string ToJson(object? value) =>
        JsonConvert.SerializeObject(value, Formatting.Indented);

    public static T? FromJson<T>(string value) =>
        JsonConvert.DeserializeObject<T>(value);
}