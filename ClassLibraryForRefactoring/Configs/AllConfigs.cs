using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClassLibraryForRefactoring
{
    public class AllConfigs
    {
        [JsonProperty("DataForBonusREG_SAL_SPO")]
        public Config[] DataForBonusREG_SAL_SPO;
        [JsonProperty("DataForDiscountREG_SAL_SPO")]
        public Config[] DataForDiscountREG_SAL_SPO;
        public AllConfigs(Config[] DataForBonusREG_SAL_SPO, Config[] DataForDiscountREG_SAL_SPO)
        {
            this.DataForBonusREG_SAL_SPO = DataForBonusREG_SAL_SPO;
            this.DataForDiscountREG_SAL_SPO = DataForDiscountREG_SAL_SPO;
        }
    }
}
