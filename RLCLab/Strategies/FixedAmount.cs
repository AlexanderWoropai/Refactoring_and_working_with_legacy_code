using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab.Strategies
{
    public class FixedAmount : IBonusStrategy
    {
        public double GetBonus(Item _item)
        { 
            switch (_item.getGoods()) 
            {
                case REG: return 10;
                case SAL: return 10;
                case SPO: return 10;
            }
            return 0;
        }
    }
}
