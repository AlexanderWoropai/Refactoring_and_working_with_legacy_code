using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCLab
{
    // Класс, представляющий данные о чеке
    public class Item
    {
        private Goods _Goods;
        private int _quantity;
        private double _price;
        public Item(Goods Goods, int quantity, double price)
        {
            _Goods = Goods;
            _quantity = quantity;
            _price = price;
        }
        public int GetBonus() 
        {
            return (int)(GetSum() * getGoods().GetBonus(_quantity, _price));
        }
        public double GetDiscount()
        {
            return GetSum() * getGoods().GetDiscount(_quantity, _price);
        }
        public double GetUsedBonus(Customer _customer)
        {
            double usedBonus = 0;
            // используем бонусы
            /*if ((getGoods().GetType() == typeof(REG)) && getQuantity() > 5)
                usedBonus = _customer.useBonus((int)(GetSum() - GetDiscount()));
            if ((getGoods().GetType() == typeof(SPO)) && getQuantity() > 1)
                usedBonus = _customer.useBonus((int)(GetSum() - GetDiscount()));*/
            usedBonus = getGoods().GetUsedBonus(_customer, this);
            return usedBonus;
        }
        public double GetSum()
        {
            return getQuantity() * getPrice();
        }
        public int getQuantity()
        {
            return _quantity;
        }
        public double getPrice()
        {
            return _price;
        }
        public Goods getGoods()
        {
            return _Goods;
        }
    }
}