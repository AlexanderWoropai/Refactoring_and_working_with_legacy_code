using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class SAL : Goods
    {
        public SAL(string title, IBonusStrategy bonusStrategy, IDiscountStrategy discountStrategy) : base(title, bonusStrategy, discountStrategy)
        {
            _title = title;
            _BonusStrategy = bonusStrategy;
            _DiscountStrategy = discountStrategy;
        }
        public override double GetUsedBonus(Customer _customer, Item item)
        {
            return 0;
        }
    }
}
