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
            "M.dd.yyyy HH:mm:ss",
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
    public class GuidConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Guid) || objectType == typeof(Guid?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var str = reader.Value?.ToString();
            if (string.IsNullOrWhiteSpace(str))
            {
                if (objectType == typeof(Guid?))
                    return null;
                return Guid.Empty;
            }

            if (Guid.TryParse(str, out var guid))
                return guid;

            throw new JsonSerializationException($"'{str}' geçerli bir Guid formatı değil.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is Guid guid)
            {
                writer.WriteValue(guid.ToString("D")); // 8-4-4-4-12 formatında
            }
            else
            {
                writer.WriteNull();
            }
        }
    }
}
