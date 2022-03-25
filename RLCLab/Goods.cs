using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCLab
{
    // Класс, который представляет данные о товаре
    public class Goods
    {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;
        private String _title;
        private int _priceCode;
        public Goods(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
        public int getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public String getTitle()
        {
            return _title;
        }
        public int GetBonus(Item item)
        {
            switch (item.getGoods().getPriceCode())
            {
                case Goods.REGULAR: return (int)(item.getQuantity() * item.getPrice() * 0.05);
                case Goods.SALE: return (int)(item.getQuantity() * item.getPrice() * 0.01);
            }
            return 0;
        }
        public double GetDiscount(Item item)
        {
            double discount = 0;
            switch (item.getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    if (item.getQuantity() > 2) discount = (item.getQuantity() * item.getPrice()) * 0.03; // 3%
                    break;
                case Goods.SPECIAL_OFFER:
                    if (item.getQuantity() > 10) discount = (item.getQuantity() * item.getPrice()) * 0.005; // 0.5%
                    break;
                case Goods.SALE:
                    if (item.getQuantity() > 3) discount = (item.getQuantity() * item.getPrice()) * 0.01; // 0.1%
                    break;
            }
            return discount;
        }
    }
}