using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace JObjectCoverter
{
    class Program
    {
        /// <summary>
        /// Set snake name convention for deserialization/serialization
        /// </summary>
        private static readonly SnakeCaseNamingStrategy SnakeNameStrategy = new SnakeCaseNamingStrategy();
        private static readonly JsonSerializerSettings JsonSerializerSettings =
            new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                Converters = new[]
                    {new JObjectCustomConverter(SnakeNameStrategy)},
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = SnakeNameStrategy
                }
            };

        static void Main(string[] args)
        {
            DeserializeJObjectTest();
            Console.ReadKey();
        }

        private static void DeserializeJObjectTest()
        {
            var text = @"{
                'nome': 'ciao',
                'id': '14',
                'today': '12/05/2017',
                'data': {
                    'first_name': 'Cristiano',
                    'last_name': 'Motta',
                   }
               }";

            // Deserialize json into typed model
            var model = DeserializeJson<ModelExample>(text);
            Console.WriteLine(model.Data);
        }

        private static void SerializeJObjectTest()
        {
            var text = @"{
                'Nominativo': 'ciao',
                'IndirizzoDiFatturazione': 'via tal dei tali',
                'FatturaDaInviare': '122222',
                'NestedObject': {
                    'FirstName': 'Cristiano',
                    'LastName': 'Motta',
                   }
               }";

            JObject jobject = JObject.Parse(text);
            var json = SerializeJson(jobject);
            Console.WriteLine(json);
        }

        private static T DeserializeJson<T>(string request)
        {
            var obj = JsonConvert.DeserializeObject<T>(request, JsonSerializerSettings);
            return obj;
        }

        private static string SerializeJson(object request)
        {
            var json = JsonConvert.SerializeObject(request, JsonSerializerSettings);
            return json;
        }
    }
}
