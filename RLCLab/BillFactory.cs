using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class BillFactory
    {
        public Bill CreateBill(TextReader reader)
        {
            var Content = new ContentFile();
            // read customer
            Customer customer = Content.GetCustomer(reader);
            Bill b = new Bill(customer);
            // read goods count
            int goodsQty = Content.GetGoodsCount(reader);
            Goods[] g = new Goods[goodsQty];
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = Content.GetNextGood(reader);
            }
            int itemsQty = Content.GetItemsCount(reader);
            for (int i = 0; i < itemsQty; i++)
            {
                b.addGoods(Content.GetNextItem(g, reader));
            }
            return b;
        }
    }
}
