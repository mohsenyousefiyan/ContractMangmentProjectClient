using System.Text.Json;

namespace ConsoleApp.Helpers
{
    public class SerializerHelper
    {
        public static T DeSerialize<T>(string json)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                };
                return JsonSerializer.Deserialize<T>(json,options);
            }
            catch
            {
                return default;
            }
        }

        public static string SerializeObject(object obj)
        {
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Serialize(obj,options);
        }
    }
}
