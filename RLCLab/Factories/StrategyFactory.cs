using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    class StrategyFactory
    {
        public IBonusStrategy BonusStrategyCreate(string type, double value_to_return, double limitation) 
        {
            if (type == "AmountForQuantity") return new AmountForQuantity(value_to_return, limitation);
            if (type == "AmountForSum") return new AmountForSum(value_to_return, limitation);
            if (type == "FixedAmount") return new FixedAmount(value_to_return);
            return null;
        }

        public IDiscountStrategy DiscountStrategyCreate(string type, double value_to_return, double limitation) 
        {
            if (type == "FixedPercentAllways") return new FixedPercentAllways(value_to_return);
            if (type == "PercentForQuantity") return new PercentForQuantity(value_to_return, limitation);
            if (type == "PercentForSum") return new PercentForSum(value_to_return, limitation);
            return null;
        }
    }
}
