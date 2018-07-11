using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace JObjectCoverter
{
    public class ModelExample
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public DateTime Today { get; set; }
        public JObject Data { get; set; }
    }
}
