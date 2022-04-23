using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClassLibraryForRefactoring
{
    public class Config
    {
        [JsonProperty("TypeOfStrategy")]
        public string TypeOfStrategy;
        [JsonProperty("value_to_return")]
        public double value_to_return;
        [JsonProperty("limitation")]
        public double limitation;
        public Config(string TypeOfStrategy, double value_to_return, double limitation)
        {
            this.TypeOfStrategy = TypeOfStrategy;
            this.value_to_return = value_to_return;
            this.limitation = limitation;
        }
    }
}
