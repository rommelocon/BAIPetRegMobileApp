using System.Text.Json;
using System.Text.Json.Serialization;

public class NullableDateTimeConverter : JsonConverter<DateTime?>
{
    private readonly string[] formats = new[]
    {
        "yyyy-MM-ddTHH:mm:ssZ",           // Standard ISO 8601
        "yyyy-MM-ddTHH:mm:ss.fffZ",       // ISO 8601 with milliseconds
        "yyyy-MM-ddTHH:mm:ss:fffffffZ"    // Custom format with extra fractional seconds
        // Add any additional formats if needed
    };

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            var dateString = reader.GetString();
            if (DateTime.TryParseExact(dateString, formats, null, System.Globalization.DateTimeStyles.None, out var dateTime))
            {
                return dateTime;
            }
        }

        throw new JsonException($"Unable to parse the date: {reader.GetString()}");
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")); // ISO 8601 format
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
