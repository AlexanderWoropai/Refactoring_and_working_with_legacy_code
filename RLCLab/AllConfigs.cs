using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RLCLab
{
    public class AllConfigs
    {
        [JsonProperty("DataForBonusREG_SAL_SPO")]
        public Config[] DataForBonusREG_SAL_SPO;
        [JsonProperty("DataForDiscountREG_SAL_SPO")]
        public Config[] DataForDiscountREG_SAL_SPO;
    }
}
