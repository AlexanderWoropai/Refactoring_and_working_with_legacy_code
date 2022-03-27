using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCLab
{
    class UsageExample
    {
        static void Example(string[] args)
        {
            Goods cola = new REG("Cola");
            Goods pepsi = new SAL("Pepsi"); 
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            IView view = new TxtView();
            Bill b1 = new Bill(x, view);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string bill = b1.GetBill();
            Console.WriteLine(bill);
        }
    }
}