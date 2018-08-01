# JObjectConverter

Custom Json Converter for JObject type using Json.net

> Serialize/Deserialize JObject type with snake name convention. By default Json.net ignore serialize settings for JObject type.


Example:
```
{
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
}
```

Result:
```
......
```


