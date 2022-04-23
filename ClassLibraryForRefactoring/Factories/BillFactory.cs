using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForRefactoring
{
    public class BillFactory
    {
        IFileSource _filesource;
        public BillFactory(IFileSource _filesource)
        {
            this._filesource = _filesource;
        }
        public Bill CreateBill(TextReader reader)
        {
            // read customer
            Customer customer = _filesource.GetCustomer(reader);
            Bill b = new Bill(customer);
            // read goods count
            int goodsQty = _filesource.GetGoodsCount(reader);
            Goods[] g = new Goods[goodsQty];
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = _filesource.GetNextGood(reader);
            }
            int itemsQty = _filesource.GetItemsCount(reader);
            for (int i = 0; i < itemsQty; i++)
            {
                b.addGoods(_filesource.GetNextItem(g, reader));
            }
            return b;
        }
    }
}
