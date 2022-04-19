﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public interface IBonusStrategy
    {
        double GetBonus(int item_quantity, double item_price);
    }
}
