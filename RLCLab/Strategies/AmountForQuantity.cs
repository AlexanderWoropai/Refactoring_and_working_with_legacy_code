using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab.Strategies
{
    class AmountForQuantity : IBonusStrategy
    {
        public double GetBonus(Item _item)
        {
            var qty = _item.getQuantity();
            switch (_item.getGoods())
            {
                case REG: if (qty > 2) return 0.03; break;
                case SAL: if (qty > 3) return 0.01; break;
                case SPO: if (qty > 10) return 0.005; break;
            }
            return 0;
        }
    }
}
