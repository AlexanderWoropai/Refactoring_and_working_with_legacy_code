using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
namespace RLCLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            string Configsfilename = "BillInfo/StrategyData.json";
            if (args.Length == 1) Configsfilename = args[0];
            var Configsfs = new FileStream(Configsfilename, FileMode.Open);
            TextReader Configsreader = new StreamReader(Configsfs);
            AllConfigs someconfigs = JsonConvert.DeserializeObject<AllConfigs>(Configsreader.ReadToEnd());

            FileSourceFactory sourceFactory = new FileSourceFactory();
            BillFactory billFactory = new BillFactory(sourceFactory.Create("TXT", someconfigs));
            string filename = "BillInfo/BillInfo.txt";
            if (args.Length == 1) filename = args[0];
            var fs = new FileStream(filename, FileMode.Open);
            TextReader reader = new StreamReader(fs);
            TextReader lr = new StringReader(reader.ReadToEnd());
            var b = billFactory.CreateBill(lr);
            string bill = new BillGenerator(new TxtView(), b).GetBill();
            Console.WriteLine(bill);
        }

        
    }
}