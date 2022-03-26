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
        public override double GetBonus()
        {
            return 0;
        }
        public override double GetDiscount(int qty)
        {
            if (qty > 10) return  0.005; // 0.5%
            return 0;
        }
    }
}
