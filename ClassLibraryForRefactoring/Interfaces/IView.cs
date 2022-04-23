using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForRefactoring
{
    public interface IView
    {
        string GetHeader(string _customer);
        string GetFooter(double totalAmount, int totalBonus);
        string GetItemString(ItemSummary _itemSummary);
    }
}
