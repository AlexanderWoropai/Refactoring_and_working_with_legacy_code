using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class FixedPercentAllways : IDiscountStrategy
    {
        double _value_to_return;
        double _limitation;
        public FixedPercentAllways(double value_to_return, double limitation = 0)
        {
            _value_to_return = value_to_return;
            _limitation = limitation;
        }
        public double GetDiscount(int item_quantity, double item_price)
        {
            return _value_to_return;
        }
    }
}
