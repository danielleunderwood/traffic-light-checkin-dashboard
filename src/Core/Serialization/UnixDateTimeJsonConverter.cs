using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Serialization;

public class UnixDateTimeJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return UnixDateTime.ToDateTime(reader.GetDouble());
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(UnixDateTime.ToUnixDateTime(value));
    }
}
