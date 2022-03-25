using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class REG : Goods
    {
        public REG(String title):base(title)
        {
            _title = title;
        }
        public override int GetBonus(Item item) 
        {
            return (int)(item.getQuantity() * item.getPrice() * 0.05);
        }
        public override double GetDiscount(Item item) 
        {
            double discount = 0;
            if(item.getQuantity() > 2) discount = (item.getQuantity() * item.getPrice()) * 0.03; // 3%
            return discount;
        }
    }
}
