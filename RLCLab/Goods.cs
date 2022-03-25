using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCLab
{
    // Класс, который представляет данные о товаре
    public class Goods 
    {
        protected String _title;
        public Goods(String title)
        {
            _title = title;
        }
        public String getTitle()
        {
            return _title;
        }
        public virtual int GetBonus(Item item)
        {
            return 0;
        }
        public virtual double GetDiscount(Item item)
        {
            return 0;
        }
    }
}