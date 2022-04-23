using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForRefactoring
{
    public interface IDiscountStrategy
    {
        double GetDiscount(int item_quantity, double item_price);
    }
}
