using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MunichPublicTransport.Misc
{
    internal class MillisecondsUnixTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                return;
            }
            
            var milliSeconds = (DateTimeOffset)value;
            writer.WriteRawValue(milliSeconds.ToUnixTimeMilliseconds().ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }
            
            var milliSeconds = (long)reader.Value;
            return DateTimeOffset.FromUnixTimeMilliseconds(milliSeconds);
        }
    }
}