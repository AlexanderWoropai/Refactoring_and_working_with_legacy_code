﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForRefactoring
{
    public class PercentForSum : IDiscountStrategy
    {
        double _value_to_return;
        double _limitation;
        public PercentForSum(double value_to_return, double limitation = 0)
        {
            _value_to_return = value_to_return;
            _limitation = limitation;
        }
        public double GetDiscount(int item_quantity, double item_price)
        {
            if (item_quantity * item_price > _limitation) return _value_to_return;
            return 0;
        }
    }
}
