using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;

namespace JObjectCoverter
{
    public class JObjectCustomConverter : JsonConverter<JObject>
    {

        private NamingStrategy NamingStrategy { get; }

        public JObjectCustomConverter(NamingStrategy strategy)
        {
            NamingStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public override void WriteJson(JsonWriter writer, JObject value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (JProperty property in value.Properties())
            {
                var name = NamingStrategy.GetPropertyName(property.Name, false);
                writer.WritePropertyName(name);
                serializer.Serialize(writer, property.Value);
            }

            writer.WriteEndObject();
        }

        public override JObject ReadJson(JsonReader reader, Type objectType, JObject existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            var json = JObject.Load(reader);
            return json;
        }
    }
}
