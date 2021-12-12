using System.Text.Json;

namespace Products.Domain.Utils.Extensions
{
    public static class JsonExtensions
    {
        public static T ToObject<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public static string ToJson(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
