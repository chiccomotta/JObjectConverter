using System;
using JObjectCoverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace JObjectConverter
{
    public class Program
    {
        private static readonly SnakeCaseNamingStrategy SnakeNameStrategy = new SnakeCaseNamingStrategy();
        private static readonly JsonSerializerSettings JsonSerializerSettings =
            new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                Converters = new[]
                    {new JObjectConverter(SnakeNameStrategy) },
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = SnakeNameStrategy
                }
            };

        static void Main(string[] args)
        {
            //DeserializeJObjectTest();
            SerializeJObjectTest();
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
                'NestedObject': [
                   {
                    'FirstName': 'Cristiano',
                    'LastName': 'Motta',
                    'Indirizzo': {
                        'ViaPrincipale':'Valeriana', 
                        'NumeroCivico': '14',
                        'LinguaggiDiProgrammazione': ['C#','Visual Basic','Javascript','PHP'],
                    'Computer': {
                        'Cpu':'Intel I7', 
                        'RAM': '16 GB',
                        'SSD': true,
                        'Versioni': [1,4,8,9,0,-1]
                    },  
                    },
                   },
                   {
                    'FirstName': 'Claudio',
                    'LastName': 'Motta',
                   }]
               }";

            var jobject = JObject.Parse(text);
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
