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
                usedBonus = GetUsedBonus(each, discount);

                // учитываем скидку
                thisAmount = GetSum(each) - discount - usedBonus;

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
        private double GetSum(Item item) 
        {
            return item.getQuantity() * item.getPrice();
        }
        private double GetUsedBonus(Item item, double discount) 
        {
            double usedBonus = 0;
            // используем бонусы
            if ((item.getGoods().GetType() == typeof(REG)) && item.getQuantity() > 5)
                usedBonus = _customer.useBonus((int)(GetSum(item)-discount));
            if ((item.getGoods().GetType() == typeof(SPO)) && item.getQuantity() > 1)
                usedBonus = _customer.useBonus((int)(GetSum(item)-discount));
            return usedBonus;
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