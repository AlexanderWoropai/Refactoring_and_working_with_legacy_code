using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RLCLab
{
    public class Config
    {
        [JsonProperty("TypeOfStrategy")]
        public string TypeOfStrategy;
        [JsonProperty("value_to_return")]
        public double value_to_return;
        [JsonProperty("limitation")]
        public double limitation;
    }
}
