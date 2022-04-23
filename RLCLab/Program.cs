using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using ClassLibraryForRefactoring;
namespace RLCLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Необходимый функционал для формы :
            //Поиск стратегии или ее создание в форме
            //Выбор формата чека YAML или TXT, или создание чека
            //Поиск чека
            //Создание текста чека в формате Txt или Html   
            string Configsfilename = "BillInfo/StrategyData.json";
            if (args.Length == 1) Configsfilename = args[0];
            var Configsfs = new FileStream(Configsfilename, FileMode.Open);
            TextReader Configsreader = new StreamReader(Configsfs);
            AllConfigs someconfigs = JsonConvert.DeserializeObject<AllConfigs>(Configsreader.ReadToEnd());

            FileSourceFactory sourceFactory = new FileSourceFactory();
            BillFactory billFactory = new BillFactory(sourceFactory.Create("YAML", someconfigs));
            string filename = "BillInfo/BillInfo.yaml";
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