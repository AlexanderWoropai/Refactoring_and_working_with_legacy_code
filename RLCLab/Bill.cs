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
                double thisAmount, discount, usedBonus;
                int bonus;
                Item each = (Item)items.Current;

                //определить сумму для каждой строки
                bonus = each.GetBonus();
                discount = each.GetDiscount();
                usedBonus = each.GetUsedBonus(_customer);

                // учитываем скидку
                thisAmount = each.GetSum() - discount - usedBonus;

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