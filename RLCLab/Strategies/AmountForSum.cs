using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab.Strategies
{
    class AmountForSum : IBonusStrategy
    {
        public double GetBonus(Item _item)
        {
            var Sum = _item.GetSum();
            switch (_item.getGoods())
            {
                case REG: if (Sum > 5000) return 0.07; break;
                case SAL: return 0.01;
                case SPO: return 0;
            }
            return 0;
        }
    }
}
