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
        public override double GetBonus()
        {
            return 0.01;
        }
        public override double GetDiscount(int qty)
        {
            if (qty > 3) return 0.01; // 0.1%
            return 0;
        }
    }
}
