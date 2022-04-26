using System.Text.Json;
using System.Text.Json.Serialization;

namespace Repository;

internal class InitializationHelper
{
    public static T Deserialize<T>(string json)
    {
        var result = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
        {
            Converters = {
                new JsonStringEnumConverter( JsonNamingPolicy.CamelCase)
            }
        });

        ArgumentNullException.ThrowIfNull(result, nameof(result));
        
        return result;
    }
}
