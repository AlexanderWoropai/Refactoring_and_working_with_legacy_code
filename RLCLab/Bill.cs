using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCLab
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }


        public String statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            String result = GetHeader();

            while (items.MoveNext())
            {
                double thisAmount = 0;
                double discount = 0;
                int bonus = 0;
                Item each = (Item)items.Current;

                //определить сумму для каждой строки
                bonus = GetBonus(each);
                discount = GetDiscount(each);

                // сумма
                thisAmount = each.getQuantity() * each.getPrice();

                // учитываем скидку
                thisAmount = each.getQuantity() * each.getPrice() - discount;

                //показать результаты
                result += each.getItemString() +
                "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
                "\t" + bonus.ToString() + "\n";

                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            //добавить нижний колонтитул
            result += GetFooter(totalAmount, totalBonus);

            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            return result;
        }


        private int GetBonus(Item item) 
        {
            switch (item.getGoods().getPriceCode()) 
            {
                case Goods.REGULAR: return (int)(item.getQuantity() * item.getPrice() * 0.05);
                case Goods.SALE: return (int)(item.getQuantity() * item.getPrice() * 0.01);
            }
            return 0;
        }
        private double GetDiscount(Item item) 
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

            // используем бонусы
            if ((item.getGoods().getPriceCode() == Goods.REGULAR) && item.getQuantity() > 5)
                discount += _customer.useBonus((int)(item.getQuantity() * item.getPrice()));
            if ((item.getGoods().getPriceCode() == Goods.SPECIAL_OFFER) && item.getQuantity() > 1)
                discount = _customer.useBonus((int)(item.getQuantity() * item.getPrice()));
            return discount;
        }
        private string GetHeader() 
        { 
            return "Счет для " + _customer.getName() + "\n"+
            "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
        }
        private string GetFooter(double totalAmount, int totalBonus) 
        {
            return "Сумма счета составляет " + totalAmount.ToString() + "\n" +
            "Вы заработали " + totalBonus.ToString() + " бонусных балов";
        }
    }
}