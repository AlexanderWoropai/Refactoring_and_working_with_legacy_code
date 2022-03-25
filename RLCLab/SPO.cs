using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class SPO : Goods
    {
        public SPO(String title) : base(title)
        {
            _title = title;
        }
        public override int GetBonus(Item item)
        {
            return 0;
        }
        public override double GetDiscount(Item item)
        {
            double discount = 0;
            if (item.getQuantity() > 10) return (item.getQuantity() * item.getPrice()) * 0.005; // 0.5%
            return discount;
        }
    }
}
