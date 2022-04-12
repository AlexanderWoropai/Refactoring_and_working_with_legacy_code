using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class GoodsFactory
    {
        public Goods Create(string type,string title) 
        {
            if (type == "REG") return new REG(title);
            if (type == "SAL") return new SAL(title);
            if (type == "SPO") return new SPO(title);
            return null;
        }
    }
}
