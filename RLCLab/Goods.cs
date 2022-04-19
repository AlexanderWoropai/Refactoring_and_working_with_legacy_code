﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCLab
{
    // Класс, который представляет данные о товаре
    public class Goods 
    {
        protected String _title;
        protected IBonusStrategy _BonusStrategy;
        protected IDiscountStrategy _DiscountStrategy;
        public Goods(String title, IBonusStrategy BonusStrategy, IDiscountStrategy DiscountStrategy)
        {
            _title = title;
            _BonusStrategy = BonusStrategy;
            _DiscountStrategy = DiscountStrategy;
        }
        public String getTitle()
        {
            return _title;
        }
        public virtual double GetUsedBonus(Customer _customer, Item item) 
        {
            return 0;
        }
        public double GetBonus(int item_quantity, double item_price)
        {
            return _BonusStrategy.GetBonus(item_quantity, item_price);
        }
        public double GetDiscount(int item_quantity, double item_price)
        {
            return _DiscountStrategy.GetDiscount(item_quantity, item_price);
        }
    }
}