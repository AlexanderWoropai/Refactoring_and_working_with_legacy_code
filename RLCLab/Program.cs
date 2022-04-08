using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace RLCLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileSourceFactory sourceFactory = new FileSourceFactory();
            BillFactory billFactory = new BillFactory(sourceFactory.Create("TXT"));
            string filename = "BillInfo.txt";
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