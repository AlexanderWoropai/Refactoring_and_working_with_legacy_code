using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RLCLab
{
    interface IComponent
    {
        Customer GetCustomer(TextReader reader);
        int GetGoodsCount(TextReader reader);
        Goods GetNextGood(TextReader reader);
        int GetItemsCount(TextReader reader);
        Item GetNextItem(Goods[] g, TextReader reader);
        string GetNextLine(TextReader reader);
    }
}
