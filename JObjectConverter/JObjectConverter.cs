using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace JObjectConverter
{
    public class JObjectConverter : JsonConverter<JObject>
    {
        private NamingStrategy NamingStrategy { get; }

        public JObjectConverter(NamingStrategy namingStrategy)
        {
            this.NamingStrategy = namingStrategy ?? throw new ArgumentNullException(nameof(namingStrategy));
        }

        public override void WriteJson(JsonWriter writer, JObject value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            foreach (var property in value.Properties())
            {
                var name = NamingStrategy.GetPropertyName(property.Name, false);
                writer.WritePropertyName(name);
                serializer.Serialize(writer, ParseToken(property.Value));
            }

            writer.WriteEndObject();
        }

        private JToken ParseToken(JToken property)
        {
            switch (property.Type)
            {
                case JTokenType.Array:
                    return RebuildJArray((JArray)property);

                case JTokenType.Object:
                    return RebuildObject((JObject)property);

                case JTokenType.Property:
                    return RebuildProperty((JProperty)property);

                default:
                    return property;
            }
        }

        private JToken RebuildProperty(JProperty property)
        {            
            return new JProperty(NamingStrategy.GetPropertyName(property.Name, false), ParseToken(property.Value));
        }

        private JToken RebuildObject(JObject array)
        {
            var jobject = new JObject();
            foreach (var property in array.Properties())
            {
                jobject.Add(ParseToken(property));
            }

            return jobject;
        }

        private JToken RebuildJArray(JArray array)
        {
            var jarray = new JArray();
            foreach (var elem in array)
            {
                jarray.Add(ParseToken(elem));
            }

            return jarray;
        }

        public override JObject ReadJson(JsonReader reader, Type objectType, JObject existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            return jsonObject;
        }
    }
}
