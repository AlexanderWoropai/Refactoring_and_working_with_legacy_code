using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForRefactoring
{
    public class YamlFileSource : IFileSource
    {
        AllConfigs _allConfigs;
        public YamlFileSource(AllConfigs allConfigs)
        {
            _allConfigs = allConfigs;
        }
        public Customer GetCustomer(TextReader reader)
        {
            // read customer
            string line = GetNextLine(reader);
            string[] result = line.Split(':');
            string name = result[1].Trim();
            // read bonus
            line = reader.ReadLine();
            result = line.Split(':');
            int bonus = Convert.ToInt32(result[1].Trim());
            return new Customer(name, bonus);
        }

        public int GetGoodsCount(TextReader reader)
        {
            string line = GetNextLine(reader);
            string[] result = line.Split(':');
            return Convert.ToInt32(result[1].Trim());
        }

        public Goods GetNextGood(TextReader reader)
        {
            var factory = new GoodsFactory(_allConfigs);
            string line;
            string[] result;
            line = GetNextLine(reader);
            result = line.Split(':');
            result = result[1].Trim().Split();
            string type = result[1].Trim();

            return factory.Create(type, result[0]); ;
        }

        public int GetItemsCount(TextReader reader)
        {
            string line;
            string[] result;
            // read items count
            line = GetNextLine(reader);
            result = line.Split(':');
            return Convert.ToInt32(result[1].Trim());
        }

        public Item GetNextItem(Goods[] g, TextReader reader)
        {
            string line;
            string[] result;
            line = GetNextLine(reader);
            result = line.Split(':');
            result = result[1].Trim().Split();
            int gid = Convert.ToInt32(result[0].Trim());
            double price = Convert.ToDouble(result[1].Trim());
            int qty = Convert.ToInt32(result[2].Trim());
            return new Item(g[gid - 1], qty, price);
        }

        public string GetNextLine(TextReader reader)
        {
            string line;
            // Пропустить комментарии
            do
            {
                line = reader.ReadLine();
            } while (line.StartsWith("#"));
            return line;
        }
    }
}
