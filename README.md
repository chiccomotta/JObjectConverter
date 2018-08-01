# JObjectConverter

Custom Json Converter for JObject type using Json.net

> Serialize/Deserialize JObject type with snake name convention. By default Json.net ignore serialize settings for JObject type.


Example of **JObject content** *(this is not a typed model, is a JObject!)*:
```
{
  'NestedObject': [
     {
      'FirstName': 'Cristiano',
      'LastName': 'Motta',
      'Indirizzo': {
          'ViaPrincipale':'Beccaria', 
          'NumeroCivico': '70',
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
{
  "nested_object": [
    {
      "first_name": "Cristiano",
      "last_name": "Motta",
      "indirizzo": {
        "via_principale": "Beccaria",
        "numero_civico": "70",
        "linguaggi_di_programmazione": ["C#","Visual Basic","Javascript","PHP"],
        "computer": {
          "cpu": "Intel I7",
          "ram": "16 GB",
          "ssd": true,
          "versioni": [1,4,8,9,0,-1]
        }
      }
    },
    {
      "first_name": "Claudio",
      "last_name": "Motta"
    }
  ]
}
```


