using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    class SPO : Goods
    {
        public SPO(string title, IBonusStrategy bonusStrategy, IDiscountStrategy discountStrategy) : base(title, bonusStrategy, discountStrategy)
        {
            _title = title;
            _BonusStrategy = bonusStrategy;
            _DiscountStrategy = discountStrategy;
        }
        public override double GetUsedBonus(Customer _customer, Item item)
        {
            if (item.getQuantity() > 1) return _customer.useBonus((int)(item.GetSum() - item.GetDiscount()));
            return 0;
        }
    }
}
