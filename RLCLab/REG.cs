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
        public override double GetBonus() 
        {
            return 0.05;
        }
        public override double GetDiscount(int qty) 
        {
            if(qty > 2) return 0.03; // 3%
            return 0;
        }
    }
}
