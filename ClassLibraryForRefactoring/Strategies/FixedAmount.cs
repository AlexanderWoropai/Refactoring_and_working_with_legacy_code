using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForRefactoring
{
    public class FixedAmount : IBonusStrategy
    {
        double _value_to_return;
        double _limitation;
        public FixedAmount(double value_to_return, double limitation = 0)
        {
            _value_to_return = value_to_return;
            _limitation = limitation;
        }
        public double GetBonus(int item_quantity, double item_price)
        {
            return _value_to_return;
        }
    }
}
