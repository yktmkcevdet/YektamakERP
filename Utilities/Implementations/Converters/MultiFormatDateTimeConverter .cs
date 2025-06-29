namespace Utilities.Implementations.Converters
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;

    public class MultiFormatDateTimeConverter : JsonConverter
    {
        private readonly string[] formats = new[]
        {
        "dd.MM.yyyy HH:mm:ss",
        "dd.MM.yyyy",
        "yyyy-MM-ddTHH:mm:ss",
        "yyyy-MM-dd",
        "yyyy-MM-dd HH:mm:ss.ffffff"
    };

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var str = reader.Value?.ToString();
            if (string.IsNullOrWhiteSpace(str))
                return objectType == typeof(DateTime?) ? null : DateTime.MinValue;

            foreach (var format in formats)
            {
                if (DateTime.TryParseExact(str, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                    return dt;
            }

            throw new JsonSerializationException($"'{str}' geçerli bir tarih formatı değil.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dt = (DateTime)value;
            writer.WriteValue(dt.ToString(formats[0]));
        }
    }
}
