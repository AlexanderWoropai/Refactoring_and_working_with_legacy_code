using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class SAL : Goods
    {
        public SAL(String title) : base(title)
        {
            _title = title;
        }
        public override int GetBonus(Item item)
        {
            return (int)(item.getQuantity() * item.getPrice() * 0.01);
        }
        public override double GetDiscount(Item item)
        {
            double discount = 0;
            if (item.getQuantity() > 3) discount = (item.getQuantity() * item.getPrice()) * 0.01; // 0.1%
            return discount;
        }
    }
}
