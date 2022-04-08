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
            BillFactory factory = new BillFactory();
            string filename = "BillInfo.yaml";
            if (args.Length == 1) filename = args[0];
            var fs = new FileStream(filename, FileMode.Open);
            TextReader reader = new StreamReader(fs);
            TextReader lr = new StringReader(reader.ReadToEnd());
            var b = factory.CreateBill(lr);
            string bill = new BillGenerator(new TxtView(), b).GetBill();
            Console.WriteLine(bill);
        }

        
    }
}