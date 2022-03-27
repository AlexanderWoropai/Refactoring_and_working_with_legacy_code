using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class TxtView : IView
    {
        public string GetFooter(double totalAmount, int totalBonus)
        {
            return "Сумма счета составляет " + totalAmount.ToString() + "\n" +
            "Вы заработали " + totalBonus.ToString() + " бонусных балов";
        }

        public string GetHeader(Customer _customer) 
        {
            return "Счет для " + _customer.getName() + "\n" +
            "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
        }

        public string GetItemString(Item item, double usedBonus)
        {
            return "\t" + item.getGoods().getTitle() + "\t" +
                "\t" + item.getPrice() + "\t" + item.getQuantity() +
                "\t" + (item.GetSum()).ToString() +
                "\t" + item.GetDiscount().ToString() + 
                "\t" + (item.GetSum() - item.GetDiscount() - usedBonus).ToString() +
                "\t" + item.GetBonus().ToString() + "\n"; ;
        }
    }
}
