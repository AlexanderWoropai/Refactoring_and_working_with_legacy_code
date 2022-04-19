using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
namespace RLCLab
{
    class UsageExample
    {
        static void Example(string[] args)
        {
            string filename = "BillInfo/StrategyData.json";
            if (args.Length == 1) filename = args[0];
            var fs = new FileStream(filename, FileMode.Open);
            TextReader reader = new StreamReader(fs);
            AllConfigs someconfigs = JsonConvert.DeserializeObject<AllConfigs>(reader.ReadToEnd());
            GoodsFactory factoryGoods = new GoodsFactory(someconfigs);

            Goods cola = factoryGoods.Create("REG", "Cola");
            Goods pepsi = factoryGoods.Create("SAL", "Pepsi");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            IView view = new TxtView();
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string bill =  new BillGenerator(new TxtView(),b1).GetBill();
            Console.WriteLine(bill);
        }
    }
}